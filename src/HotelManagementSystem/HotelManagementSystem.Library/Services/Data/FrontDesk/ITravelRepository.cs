using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Services.Data.FrontDesk
{
    public interface ITravelPartnerRepository : IRepository<TravelPartner>
    {
        Task AddTravelPartners(List<TravelPartner> travelPartners);
        IEnumerable<TravelPartner> GetByBookingId(int bookingId);
    }
}