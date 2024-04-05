using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomLevel { get; set; } = 0;
        [Required]
        public int RoomNumber { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

    }
}
