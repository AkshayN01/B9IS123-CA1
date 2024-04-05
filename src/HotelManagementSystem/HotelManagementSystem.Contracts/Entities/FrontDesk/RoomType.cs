namespace HotelManagementSystem.Contracts.Entities.FrontDesk
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public Double Price { get; set; }
        public int MaxCapacity { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
