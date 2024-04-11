using HotelManagementSystem.Contracts.Entities.FrontDesk;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.APIModels.FontDesk
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; } = 0;
        [Required]
        public int RoomNumber { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int RoomTypeId { get; set; }
        public RoomTypeModel RoomType { get; set; }
    }
}
