using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.FrontDesk.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    Branchd = table.Column<int>(type: "int", nullable: false),
                    BookingFromDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BookingToDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BookinStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.Guid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomStatuses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatuses", x => x.Guid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ShortName = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Gender = table.Column<string>(type: "longtext", nullable: false),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: false),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false),
                    Zipcode = table.Column<string>(type: "longtext", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: false),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TravelPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    VisitorPartnerId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPartners_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoomLevel = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "longtext", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    RoomReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserGuid = table.Column<string>(type: "longtext", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalAmount = table.Column<double>(type: "double", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    RoomStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.RoomReservationId);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Guid", "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12fa6050-a299-4704-ac73-1f1f6087b985"), 3, "Declined" },
                    { new Guid("4c9b82dd-2f8e-4d55-967f-378442a76609"), 2, "Approved" },
                    { new Guid("98023d7c-7798-4f82-b784-ffcb592c02b6"), 1, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "RoomStatuses",
                columns: new[] { "Guid", "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("288c5d89-8f85-4da1-9472-146f7d7cfc11"), 2, "Vacant" },
                    { new Guid("69197f20-d0f2-45b5-8823-b4d0cb30e204"), 3, "CleaningInProgress" },
                    { new Guid("df692d88-a45d-4d8a-a19b-139640562e3e"), 1, "Booked" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Description", "MaxCapacity", "Name", "Price", "ShortName" },
                values: new object[,]
                {
                    { 1, "Presidential Suite", 2, "Presidential Suite", 3000.0, "PresidentialSuite" },
                    { 2, "Delux Room", 2, "Delux Room", 1500.0, "Delux" },
                    { 3, "Economy Room", 2, "Economy", 800.0, "Economy" },
                    { 4, "Dormitory", 8, "Dormitory", 60.0, "Dormitory" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomLevel", "RoomName", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1, "101", 101, 4 },
                    { 2, 1, "102", 102, 4 },
                    { 3, 2, "201", 201, 3 },
                    { 4, 2, "202", 202, 3 },
                    { 5, 2, "203", 203, 3 },
                    { 6, 2, "204", 204, 3 },
                    { 7, 3, "301", 301, 3 },
                    { 8, 3, "302", 302, 3 },
                    { 9, 3, "303", 303, 3 },
                    { 10, 3, "304", 304, 3 },
                    { 11, 4, "401", 401, 2 },
                    { 12, 4, "402", 402, 2 },
                    { 13, 4, "403", 403, 2 },
                    { 14, 5, "502", 501, 2 },
                    { 15, 5, "502", 502, 2 },
                    { 16, 5, "504", 503, 2 },
                    { 17, 6, "601", 601, 1 },
                    { 18, 6, "602", 602, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_BookingId",
                table: "RoomReservations",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomId",
                table: "RoomReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPartners_BookingId",
                table: "TravelPartners",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Email",
                table: "Visitors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Phone",
                table: "Visitors",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_UserName",
                table: "Visitors",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "RoomStatuses");

            migrationBuilder.DropTable(
                name: "TravelPartners");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
