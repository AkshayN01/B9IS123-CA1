namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class HotelBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int IsCurrent { get; set; }
        public bool IsActive { get; set; }
    }
}
