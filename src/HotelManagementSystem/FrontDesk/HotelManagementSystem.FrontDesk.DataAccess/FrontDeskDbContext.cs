using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Contracts.Entities.FrontDesk;
using HotelManagementSystem.Contracts.Entities.Visitor;
using HotelManagementSystem.FrontDesk.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.FrontDesk.DataAccess
{
    public class FrontDeskDbContext : DbContext
    {
        public FrontDeskDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomStatus> RoomStatuses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<TravelPartner> TravelPartners { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomStatus>().HasData(FrontDeskData.GetRoomStatuses());
            modelBuilder.Entity<RoomType>().HasData(FrontDeskData.GetRoomTypes());
            modelBuilder.Entity<Room>().HasData(FrontDeskData.GetAllRooms());

            modelBuilder.Entity<BookingStatus>().HasData(FrontDeskData.GetAllBookingStatuses());
        }
    }
}
