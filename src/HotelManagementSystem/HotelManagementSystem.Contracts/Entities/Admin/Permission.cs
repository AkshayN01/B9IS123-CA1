using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [Required]
        public int HotelBranchId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }

        public ICollection<PermissionAssignment> PermissionAssignments { get; set; } = new List<PermissionAssignment>();
    }
}
