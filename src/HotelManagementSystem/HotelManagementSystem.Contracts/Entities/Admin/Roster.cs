﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class Roster
    {
        [Key]
        public int RosterId { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual Shift Shift { get; set; } = null!;
        public virtual User User { get; set; } = null!;

    }
}
