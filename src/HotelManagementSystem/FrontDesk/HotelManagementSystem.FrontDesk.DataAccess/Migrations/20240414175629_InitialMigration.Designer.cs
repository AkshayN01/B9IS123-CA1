﻿// <auto-generated />
using System;
using HotelManagementSystem.FrontDesk.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.FrontDesk.DataAccess.Migrations
{
    [DbContext(typeof(FrontDeskDbContext))]
    [Migration("20240414175629_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookinStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookingFromDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("BookingToDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Branchd")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.BookingStatus", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Guid");

                    b.ToTable("BookingStatuses");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("98023d7c-7798-4f82-b784-ffcb592c02b6"),
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Guid = new Guid("4c9b82dd-2f8e-4d55-967f-378442a76609"),
                            Id = 2,
                            Name = "Approved"
                        },
                        new
                        {
                            Guid = new Guid("12fa6050-a299-4704-ac73-1f1f6087b985"),
                            Id = 3,
                            Name = "Declined"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoomLevel")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            RoomLevel = 1,
                            RoomName = "101",
                            RoomNumber = 101,
                            RoomTypeId = 4
                        },
                        new
                        {
                            RoomId = 2,
                            RoomLevel = 1,
                            RoomName = "102",
                            RoomNumber = 102,
                            RoomTypeId = 4
                        },
                        new
                        {
                            RoomId = 3,
                            RoomLevel = 2,
                            RoomName = "201",
                            RoomNumber = 201,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 4,
                            RoomLevel = 2,
                            RoomName = "202",
                            RoomNumber = 202,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 5,
                            RoomLevel = 2,
                            RoomName = "203",
                            RoomNumber = 203,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 6,
                            RoomLevel = 2,
                            RoomName = "204",
                            RoomNumber = 204,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 7,
                            RoomLevel = 3,
                            RoomName = "301",
                            RoomNumber = 301,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 8,
                            RoomLevel = 3,
                            RoomName = "302",
                            RoomNumber = 302,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 9,
                            RoomLevel = 3,
                            RoomName = "303",
                            RoomNumber = 303,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 10,
                            RoomLevel = 3,
                            RoomName = "304",
                            RoomNumber = 304,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomId = 11,
                            RoomLevel = 4,
                            RoomName = "401",
                            RoomNumber = 401,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 12,
                            RoomLevel = 4,
                            RoomName = "402",
                            RoomNumber = 402,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 13,
                            RoomLevel = 4,
                            RoomName = "403",
                            RoomNumber = 403,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 14,
                            RoomLevel = 5,
                            RoomName = "502",
                            RoomNumber = 501,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 15,
                            RoomLevel = 5,
                            RoomName = "502",
                            RoomNumber = 502,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 16,
                            RoomLevel = 5,
                            RoomName = "504",
                            RoomNumber = 503,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomId = 17,
                            RoomLevel = 6,
                            RoomName = "601",
                            RoomNumber = 601,
                            RoomTypeId = 1
                        },
                        new
                        {
                            RoomId = 18,
                            RoomLevel = 6,
                            RoomName = "602",
                            RoomNumber = 602,
                            RoomTypeId = 1
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomReservation", b =>
                {
                    b.Property<int>("RoomReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomStatusId")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double");

                    b.Property<string>("UserGuid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoomReservationId");

                    b.HasIndex("BookingId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomReservations");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomStatus", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Guid");

                    b.ToTable("RoomStatuses");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("df692d88-a45d-4d8a-a19b-139640562e3e"),
                            Id = 1,
                            Name = "Booked"
                        },
                        new
                        {
                            Guid = new Guid("288c5d89-8f85-4da1-9472-146f7d7cfc11"),
                            Id = 2,
                            Name = "Vacant"
                        },
                        new
                        {
                            Guid = new Guid("69197f20-d0f2-45b5-8823-b4d0cb30e204"),
                            Id = 3,
                            Name = "CleaningInProgress"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Presidential Suite",
                            MaxCapacity = 2,
                            Name = "Presidential Suite",
                            Price = 3000.0,
                            ShortName = "PresidentialSuite"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Delux Room",
                            MaxCapacity = 2,
                            Name = "Delux Room",
                            Price = 1500.0,
                            ShortName = "Delux"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Economy Room",
                            MaxCapacity = 2,
                            Name = "Economy",
                            Price = 800.0,
                            ShortName = "Economy"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Dormitory",
                            MaxCapacity = 8,
                            Name = "Dormitory",
                            Price = 60.0,
                            ShortName = "Dormitory"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.TravelPartner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorPartnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("TravelPartners");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.Visitor.Visitor", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ExpiredAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VisitorId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.Room", b =>
                {
                    b.HasOne("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomReservation", b =>
                {
                    b.HasOne("HotelManagementSystem.Contracts.Entities.FrontDesk.Booking", "Booking")
                        .WithMany("Reservations")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementSystem.Contracts.Entities.FrontDesk.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.TravelPartner", b =>
                {
                    b.HasOne("HotelManagementSystem.Contracts.Entities.FrontDesk.Booking", null)
                        .WithMany("TravelPartners")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.Booking", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("TravelPartners");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.Room", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.Contracts.Entities.FrontDesk.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}