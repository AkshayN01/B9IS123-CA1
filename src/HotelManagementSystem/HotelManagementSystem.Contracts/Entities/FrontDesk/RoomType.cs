namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public String ShortName { get; set; } = String.Empty;
        public Double Price { get; set; }
        public int MaxCapacity { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
