using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class UserPasswordResets
    {
        [Key]
        public int UserPasswordResetsId { get; set; }
        public int UserId { get; set; }
        public string PasswordResetToken { get; set; } = string.Empty;
        public DateTime? ExpiresOn { get; set; }
        public bool IsEmailSent { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
