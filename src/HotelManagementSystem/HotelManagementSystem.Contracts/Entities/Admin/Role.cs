using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int HotelBranchId { get; set; }
        [MaxLength(30)]
        public string ShortName { get; set; } = string.Empty;
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<RoleAssignment> RoleAssignments { get; set; } = new List<RoleAssignment>();
        public ICollection<PermissionAssignment> PermissionAssignments { get; set; } = new List<PermissionAssignment>();
    }
}
