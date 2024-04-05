using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class HotelBranch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(15)]
        public string City { get; set; } = string.Empty;
        public int IsCurrent { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
