using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    [Index(nameof(UserName), IsUnique = true), Index(nameof(Email), IsUnique = true), Index(nameof(Phone), IsUnique = true)]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int HotelBranchId { get; set; }
        [Required]
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100), PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(16)]
        public string Phone { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zipcode { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public bool IsExpired { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Roster> Rosters { get; set; } = new HashSet<Roster>();
        public ICollection<RoleAssignment> RoleAssignments { get; set; } = new HashSet<RoleAssignment>();
        public ICollection<UserPasswordResets> UserPasswordResets { get; set; } = new HashSet<UserPasswordResets>();
    }
}
