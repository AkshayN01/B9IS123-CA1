using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.APIModels.FontDesk
{
    public class BookingModel
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BranchId { get; set; }
        public List<RoomModel> Room { get; set; } = new List<RoomModel>();
        public List<VisitorModel> Visitors { get; set; } = new List<VisitorModel>();
    }

    public class BookingSummary
    {
        public int totalData { get; set; }
        public List<BookingInfo> BookingInfo { get; set; } = new List<BookingInfo>();
    }

    public class BookingInfo
    {
        public int Id { get; set; }
        public string VisitorName { get; set; }
        public string status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}