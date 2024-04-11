using HotelManagementSystem.Contracts.Entities.FrontDesk;

namespace HotelManagementSystem.FrontDesk.DataAccess.Data
{
    public static class FrontDeskData
    {
        public static List<RoomStatus> GetRoomStatuses()
        {
            return new List<RoomStatus>()
            {
                new RoomStatus() { Guid = Guid.NewGuid(), Id = 1, Name = "Booked" },
                new RoomStatus() { Guid = Guid.NewGuid(), Id = 2, Name = "Vacant" },
                new RoomStatus() { Guid = Guid.NewGuid(), Id = 3, Name = "CleaningInProgress" },
            };
        }

        public static List<RoomType> GetRoomTypes()
        {
            return new List<RoomType>()
            {
                new RoomType() { Id = 1, Name = "Presidential Suite", Description = "Presidential Suite", MaxCapacity = 2, Price = 3000, ShortName = "PresidentialSuite" },
                new RoomType() { Id = 2, Name = "Delux Room", Description = "Delux Room", MaxCapacity = 2, Price = 1500, ShortName = "Delux" },
                new RoomType() { Id = 3, Name = "Economy", Description = "Economy Room", MaxCapacity = 2, Price = 800, ShortName = "Economy" },
                new RoomType() { Id = 4, Name = "Dormitory", Description = "Dormitory", MaxCapacity = 8, Price = 60, ShortName = "Dormitory" }
            };
        }

        public static List<BookingStatus> GetAllBookingStatuses()
        {
            return new List<Contracts.Entities.FrontDesk.BookingStatus>()
            {
                new BookingStatus() { Guid = Guid.NewGuid(), Id = 1, Name = "Pending" },
                new BookingStatus() { Guid = Guid.NewGuid(), Id = 2, Name = "Approved" },
                new BookingStatus() { Guid = Guid.NewGuid(), Id = 3, Name = "Declined" },
            };
        }

        public static List<Room> GetAllRooms()
        {
            return new List<Room>()
            {
                //Dormitory
                new Room() {RoomId = 1, RoomLevel = 1, RoomName = "101", RoomNumber = 101, RoomTypeId = 4},
                new Room() {RoomId = 2, RoomLevel = 1, RoomName = "102", RoomNumber = 102, RoomTypeId = 4},

                //Economy
                new Room() {RoomId = 3, RoomLevel = 2, RoomName = "201", RoomNumber = 201, RoomTypeId = 3},
                new Room() {RoomId = 4, RoomLevel = 2, RoomName = "202", RoomNumber = 202, RoomTypeId = 3},
                new Room() {RoomId = 5, RoomLevel = 2, RoomName = "203", RoomNumber = 203, RoomTypeId = 3},
                new Room() {RoomId = 6, RoomLevel = 2, RoomName = "204", RoomNumber = 204, RoomTypeId = 3},
                new Room() {RoomId = 7, RoomLevel = 3, RoomName = "301", RoomNumber = 301, RoomTypeId = 3},
                new Room() {RoomId = 8, RoomLevel = 3, RoomName = "302", RoomNumber = 302, RoomTypeId = 3},
                new Room() {RoomId = 9, RoomLevel = 3, RoomName = "303", RoomNumber = 303, RoomTypeId = 3},
                new Room() {RoomId = 10, RoomLevel = 3, RoomName = "304", RoomNumber = 304, RoomTypeId = 3},

                //Delux
                new Room() {RoomId = 11, RoomLevel = 4, RoomName = "401", RoomNumber = 401, RoomTypeId = 2},
                new Room() {RoomId = 12, RoomLevel = 4, RoomName = "402", RoomNumber = 402, RoomTypeId = 2},
                new Room() {RoomId = 13, RoomLevel = 4, RoomName = "403", RoomNumber = 403, RoomTypeId = 2},
                new Room() {RoomId = 14, RoomLevel = 5, RoomName = "502", RoomNumber = 501, RoomTypeId = 2},
                new Room() {RoomId = 15, RoomLevel = 5, RoomName = "502", RoomNumber = 502, RoomTypeId = 2},
                new Room() {RoomId = 16, RoomLevel = 5, RoomName = "504", RoomNumber = 503, RoomTypeId = 2},

                //PresidentialSuite
                new Room() {RoomId = 17, RoomLevel = 6, RoomName = "601", RoomNumber = 601, RoomTypeId = 1},
                new Room() {RoomId = 18, RoomLevel = 6, RoomName = "602", RoomNumber = 602, RoomTypeId = 1},
            };
        }
    }
}
