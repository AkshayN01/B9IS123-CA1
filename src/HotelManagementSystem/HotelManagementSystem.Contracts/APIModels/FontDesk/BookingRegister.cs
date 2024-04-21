using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.APIModels.FontDesk
{
    public class BookingRegisterModel
    {
        [Required]
        public string FromDate { get; set; }
        [Required]
        public string ToDate { get; set; }
        public List<int> RoomIds { get; set; }
        public List<VisitorModel> Visitors { get; set; }
    }

}