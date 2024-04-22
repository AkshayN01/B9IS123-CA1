using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
using HotelManagementSystem.Contracts.Enums;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.FrontDesk;
using System.Globalization;
using System.Linq.Expressions;
using static Mysqlx.Expect.Open.Types;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace HotelManagementSystem.FrontDesk.Blanket.Booking
{
    public class BookingBlanket
    {
        private readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        private readonly HotelBranchService _hotelBranchService;
        public BookingBlanket(IFrontDeskUnitOfWork frontDeskUnitOfWork, HotelBranchService hotelBranchService)
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
            _hotelBranchService = hotelBranchService;
        }

        public async Task<HTTPResponse> AddBooking(BookingRegisterModel bookingModel, string userGuid)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;
            string format = "dd/MM/yyyy HH:mm:ss";

            try
            {
                //Check if Valid dates
                DateTime fromDate = DateTime.ParseExact(bookingModel.FromDate, format, null);
                DateTime toDate = DateTime.ParseExact(bookingModel.ToDate, format, null);
                DateTime todaysDate = DateTime.Now;

                if (fromDate.Date > toDate.Date)
                    throw new Exception("From date is greater than toDate");
                if(fromDate.Date < todaysDate.Date)
                    throw new Exception("Cannot book for previous dates");

                Contracts.Entities.FrontDesk.Booking booking = new Contracts.Entities.FrontDesk.Booking()
                {
                    BookingFromDate = fromDate,
                    BookingToDate = toDate,
                    BookinStatusId = (int)BookinStatusEnum.Approved,
                    Branchd = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = userGuid
                };
                List<int> travelPartnerIds = new List<int>();

                //Add Visitors
                if (bookingModel.Visitors.Any())
                {
                    var primaryVisitor = bookingModel.Visitors.Find(x => x.IsPrimary == 1);
                    if (primaryVisitor == null)
                        throw new Exception("No Primary Visitor found");

                    Visitor visitor = new Visitor()
                    {
                        FirstName = primaryVisitor.FirstName,
                        LastName = primaryVisitor.LastName,
                        MiddleName = primaryVisitor.MiddleName,
                        UserName = Guid.NewGuid().ToString(),
                        Email = primaryVisitor.Email,
                        Phone = primaryVisitor.Phone,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = userGuid,
                        IsActive = true,
                        IsDeleted = false                        
                    };

                    booking.VisitorId = await _frontDeskUnitOfWork.VisitorRepository.AddVisitorDetails(visitor);
                    if (bookingModel.Visitors.Count > 1)
                    {
                        List<Visitor> travelPartners = new List<Visitor>();
                        var partners = bookingModel.Visitors.FindAll(x => x.IsPrimary == 0);
                        foreach (var partner in partners)
                        {
                            travelPartners.Add(new Visitor()
                            {
                                FirstName = partner.FirstName,
                                LastName = partner.LastName,
                                MiddleName = partner.MiddleName,
                                Email = Library.Generic.Generic.GenerateRandomString(Random.Shared.Next(16))+"@test.com",
                                Phone = Convert.ToString(Random.Shared.Next(16)),
                                UserName = Guid.NewGuid().ToString(),
                                CreatedAt = DateTime.UtcNow,
                                CreatedBy = userGuid,
                                IsActive = true,
                                IsDeleted = false
                            });
                        }
                        travelPartnerIds = await _frontDeskUnitOfWork.VisitorRepository.AddMultipleVisitors(travelPartners);
                    }
                }

                int bookingId = await _frontDeskUnitOfWork.BookingRepository.AddBookingDetails(booking);

                //Add Travel Partner
                if (travelPartnerIds.Any()) 
                {
                    List<TravelPartner> travelPartners = new List<TravelPartner>();
                    foreach(int id in travelPartnerIds)
                    {
                        travelPartners.Add(new TravelPartner()
                        {
                            BookingId = bookingId,
                            VisitorId = booking.VisitorId,
                            VisitorPartnerId = id
                        });
                    }
                    await _frontDeskUnitOfWork.TravelPartnerRepository.AddTravelPartners(travelPartners);
                }

                if (bookingModel.RoomIds.Any())
                {
                    List<RoomReservation> reservations = new List<RoomReservation>();
                    foreach (var room in bookingModel.RoomIds) {
                        reservations.Add(new RoomReservation()
                        {
                            BookingId = bookingId,
                            BranchId = 1,
                            CheckInDate = booking.BookingFromDate,
                            CheckOutDate = booking.BookingToDate,
                            IsActive = 1,
                            RoomId = room,
                            UserGuid = userGuid,
                            RoomStatusId = (int)RoomStatusEnum.Booked
                        });
                    }
                    await _frontDeskUnitOfWork.ReservationRepository.AddReservationDetails(reservations);
                }
                dynamic bookingIdDetail = new System.Dynamic.ExpandoObject();
                bookingIdDetail.BookingId = bookingId;
                retVal = 1;
                data = bookingIdDetail;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
        
        public async Task<HTTPResponse> UpdateBooking(BookingUpdateModel bookingModel, string userGuid)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                if (bookingModel.BookingId <= 0)
                    throw new Exception("Invalid booking id");

                if (!bookingModel.RoomIds.Any())
                    throw new Exception("No room ids provided");

                //get booking details
                Contracts.Entities.FrontDesk.Booking booking = await _frontDeskUnitOfWork.BookingRepository.GetAsync(bookingModel.BookingId);
                if (booking == null)
                    throw new Exception("No Booking found");

                //get booking reservations and make them inactive
                List<RoomReservation> reservations = _frontDeskUnitOfWork.ReservationRepository.GetRoomReservationsByBookingId(booking.BookingId).ToList();

                if (reservations.Any())
                {
                    foreach(RoomReservation reservation in reservations)
                    {
                        reservation.IsActive = 0;
                        reservation.RoomStatusId = (int)RoomStatusEnum.Cancelled;
                    }
                    await _frontDeskUnitOfWork.ReservationRepository.UpdateReservationDetails(reservations);
                }

                //add new reservations
                List<RoomReservation> reservations1 = new List<RoomReservation>();
                foreach (var room in bookingModel.RoomIds)
                {
                    reservations1.Add(new RoomReservation()
                    {
                        BookingId = booking.BookingId,
                        BranchId = 1,
                        CheckInDate = booking.BookingFromDate,
                        CheckOutDate = booking.BookingToDate,
                        IsActive = 1,
                        RoomId = room,
                        UserGuid = userGuid,
                        RoomStatusId = (int)RoomStatusEnum.Booked
                    });
                }
                await _frontDeskUnitOfWork.ReservationRepository.AddReservationDetails(reservations);

                retVal = 1;
                data = retVal;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }

        public async Task<HTTPResponse> GetBookingDetails(int bookingId)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                Contracts.Entities.FrontDesk.Booking booking = await _frontDeskUnitOfWork.BookingRepository.GetAsync(bookingId);

                if (booking == null)
                {
                    return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, "No such BookingId exists");
                }

                BookingModel bookingModel = new BookingModel()
                {
                    Id  = booking.BookingId,
                    BranchId = booking.Branchd,
                    FromDate = booking.BookingFromDate,
                    ToDate = booking.BookingToDate
                };

                var bookingStatus = (BookinStatusEnum)booking.BookinStatusId;
                bookingModel.Status = bookingStatus.ToString();

                //If Booking is approved, get visitor and Room details
                if (booking.BookinStatusId == (int)BookinStatusEnum.Approved)
                {
                    //Get Visitor Data
                    if (booking.VisitorId != 0)
                    {
                        Visitor visitor = await _frontDeskUnitOfWork.VisitorRepository.GetAsync(booking.VisitorId);
                        if (visitor == null)
                            return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, "Inconsistency in data. Visitor mentioned in the booking doesn't exist");

                        var visitorModel = new VisitorModel()
                        {
                            Id = visitor.VisitorId,
                            FirstName = visitor.FirstName,
                            MiddleName = visitor.MiddleName,
                            LastName = visitor.LastName,
                            Email = visitor.Email,
                            Phone = visitor.Phone,
                            IsPrimary = 0
                        };

                        bookingModel.Visitors.Add(visitorModel);
                        //Get Travel Partner Details
                        var travelPartnerIds = _frontDeskUnitOfWork.TravelPartnerRepository.GetByBookingId(booking.BookingId)
                            .Select(x => x.VisitorPartnerId)
                            .ToList();
                        if (travelPartnerIds.Any())
                        {
                            var partners = _frontDeskUnitOfWork.VisitorRepository
                               .GetAllVisitors(travelPartnerIds)
                               .Select(x => new VisitorModel()
                               {
                                   Id = x.VisitorId,
                                   FirstName = x.FirstName,
                                   MiddleName = x.MiddleName,
                                   LastName = x.LastName,
                                   IsPrimary = 0
                               });

                            bookingModel.Visitors.AddRange(partners);
                        }
                    }
                    
                    var roomIds = _frontDeskUnitOfWork.ReservationRepository
                        .GetRoomReservationsByBookingId(booking.BookingId)
                        .Select(x => x.RoomId).ToList();

                    if (roomIds.Any())
                    {
                        var roomDetails = _frontDeskUnitOfWork.RoomRepository.GetRoomsByRoomIds(roomIds)
                            .Select(x => new RoomModel()
                            {
                                Id = x.RoomId,
                                Level = x.RoomLevel,
                                RoomName = x.RoomName,
                                RoomNumber = x.RoomNumber,
                                RoomType = new RoomTypeModel()
                                {
                                    Id = x.RoomType.Id,
                                    Name = x.RoomType.Name,
                                    Price  = x.RoomType.Price,
                                    MaxCapacity = x.RoomType.MaxCapacity
                                }
                            });

                        bookingModel.Room.AddRange(roomDetails);
                    }

                }
                else if(booking.BookinStatusId == (int)BookinStatusEnum.Declined)
                {

                }
                retVal = 1;
                data = bookingModel;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }

        public async Task<HTTPResponse> GetAllBookings(string fromDate, string toDate, string bookingStatus, int pageNumber, int pageSize)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                if (pageNumber <= 0 || pageSize <= 0)
                    throw new Exception("Invalid page size and number");

                List<Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>>> expressions =
                    new List<Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>>>();

                //Get current brnachId
                var branch = await _hotelBranchService.GetCurrentInstance();
                BookingSummary bookingSummary = new BookingSummary();

                Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>> branchExpression = x => x.Branchd == branch.Id;
                expressions.Add(branchExpression);

                //Add From date condition to search the repository
                if (!string.IsNullOrEmpty(fromDate)) {
                    Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>> expression = x => x.BookingFromDate >= DateTime.Parse(fromDate);
                    expressions.Add(expression);
                }

                //Add to date condition to search the repository
                if (!string.IsNullOrEmpty(toDate))
                {
                    Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>> expression = x => x.BookingToDate <= DateTime.Parse(toDate);
                    expressions.Add(expression);
                }

                //Add status condition to search the repository
                if (!string.IsNullOrEmpty(bookingStatus))
                {
                    int statusID = GetBookingStatusByName(bookingStatus);
                    Expression<Func<Contracts.Entities.FrontDesk.Booking, bool>> expression = x => x.BookinStatusId == statusID;
                    expressions.Add(expression);
                }

                // Combine the conditions
                var combinedCondition = Library.Generic.Generic.CombineConditions<Contracts.Entities.FrontDesk.Booking>(expressions);

                var bookingsData =  _frontDeskUnitOfWork.BookingRepository.GetAllBookingDetails(combinedCondition);
                bookingSummary.totalData = bookingsData.Count();
                List<Contracts.Entities.FrontDesk.Booking> bookings = bookingsData.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


                if (bookings.Any())
                {
                    foreach(var booking in bookings)
                    {
                        BookingInfo info = new BookingInfo()
                        {
                            Id = booking.BookingId,
                            FromDate = booking.BookingFromDate,
                            ToDate = booking.BookingToDate,
                            status = GetBookingStatusById(booking.BookinStatusId)
                        };
                        Visitor visitor = await _frontDeskUnitOfWork.VisitorRepository.GetAsync(booking.VisitorId);

                        info.VisitorName = visitor.FirstName + " " + visitor.MiddleName + " " + visitor.LastName;

                        bookingSummary.BookingInfo.Add(info);
                    }
                    retVal = 1;
                    data = bookingSummary;
                }
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
        public async Task<HTTPResponse> UpdateBookingStatus(int id, int statusId, string userGuid)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;
            try
            {
                //Check if Valid booking
                Contracts.Entities.FrontDesk.Booking booking = await _frontDeskUnitOfWork.BookingRepository.GetAsync(id);

                if (booking == null)
                    throw new Exception("Invalid booking");

                //Get Room Reservation
                List<Contracts.Entities.FrontDesk.RoomReservation> roomReservations = _frontDeskUnitOfWork.ReservationRepository.GetRoomReservationsByBookingId(booking.BookingId).ToList();

                if(roomReservations.Any())
                {
                    foreach(var reservation in roomReservations)
                    {
                        reservation.RoomStatusId = (int)RoomStatusEnum.Cancelled;
                        reservation.IsActive = 0;
                    }

                    await _frontDeskUnitOfWork.ReservationRepository.UpdateReservationDetails(roomReservations);
                }

                booking.BookinStatusId = (int)((BookinStatusEnum)statusId);
                booking.UpdatedBy = userGuid;

                _frontDeskUnitOfWork.BookingRepository.Update(booking);

                _frontDeskUnitOfWork.Commit();

                retVal = 1;
                data = retVal;
            }
            catch (Exception ex)
            {
                retVal = -50;
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }

        private int GetBookingStatusByName(string name)
        {
            int id = 0;
            switch (name)
            {
                case "pending":
                    id = 1;
                    break;

                case "approved":
                    id = 2;
                    break;

                case "declined":
                    id = 3;
                    break;
            }

            return id;
        }

        private string GetBookingStatusById(int id)
        {
            string name = string.Empty;
            switch (id)
            {
                case 1:
                    name = "pending";
                    break;

                case 2:
                    name = "approved";
                    break;

                case 3:
                    name = "declined";
                    break;

                case 4:
                    name = "cancelled";
                    break;
            }

            return name;
        }
    }
}