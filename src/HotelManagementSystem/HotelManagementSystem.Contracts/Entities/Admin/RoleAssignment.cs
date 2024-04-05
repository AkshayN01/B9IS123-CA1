using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class RoleAssignment
    {
        [Key]
        public int RoleAssignmentId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int HotelBranchId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? ExpiredAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
