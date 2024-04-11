using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
using HotelManagementSystem.Contracts.Enums;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services.Data.FrontDesk;

namespace HotelManagementSystem.FrontDesk.Blanket.Booking
{
    public class BookingBlanket
    {
        private readonly IFrontDeskUnitOfWork _frontDeskUnitOfWork;
        public BookingBlanket(IFrontDeskUnitOfWork frontDeskUnitOfWork)
        {
            _frontDeskUnitOfWork = frontDeskUnitOfWork;
        }

        public async Task<HTTPResponse> AddBooking(BookingRegisterModel bookingModel, string userGuid)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                Contracts.Entities.FrontDesk.Booking booking = new Contracts.Entities.FrontDesk.Booking()
                {
                    BookingFromDate = bookingModel.FromDate,
                    BookingToDate = bookingModel.ToDate,
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
                                Email = partner.Email,
                                Phone = partner.Phone,
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

        public async Task<HTTPResponse> GetBookingDetails(int bookingId)
        {
            Object data = default(Object);
            int retVal = -40;
            string message = string.Empty;

            try
            {
                BookingModel bookingModel = new BookingModel();

                Contracts.Entities.FrontDesk.Booking booking = await _frontDeskUnitOfWork.BookingRepository.GetAsync(bookingId);

                if (booking == null)
                {
                    return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, "No such BookingId exists");
                }

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
    }
}