using HotelManagementSystem.Contracts.APIModels.FontDesk;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
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

        public async Task<HTTPResponse> AddBooking(BookingModel bookingModel, string userGuid)
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
                    BookinStatusId = 1,
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

                if (bookingModel.Room.Any())
                {
                    List<RoomReservation> reservations = new List<RoomReservation>();
                    foreach (var room in bookingModel.Room) {
                        reservations.Add(new RoomReservation()
                        {
                            BookingId = bookingId,
                            BranchId = 1,
                            CheckInDate = booking.BookingFromDate,
                            CheckOutDate = booking.BookingToDate,
                            IsActive = 1,
                            RoomId = room.Id,
                            UserGuid = userGuid,
                            RoomStatusId = 1
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
    }
}
