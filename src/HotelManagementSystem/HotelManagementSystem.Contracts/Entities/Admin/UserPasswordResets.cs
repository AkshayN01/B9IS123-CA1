namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class UserPasswordResets
    {
        public int UserPasswordResetsId { get; set; }
        public int UserId { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public bool IsEmailSent { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; }
    }
}
