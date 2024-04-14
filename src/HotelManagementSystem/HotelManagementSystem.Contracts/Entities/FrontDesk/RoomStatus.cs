﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class RoomStatus
    {
        [Key]
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
