using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Admin.DataAccess.Migrations
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
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    IsCurrent = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShiftName = table.Column<string>(type: "longtext", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Gender = table.Column<string>(type: "longtext", nullable: true),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: true),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    State = table.Column<string>(type: "longtext", nullable: true),
                    Country = table.Column<string>(type: "longtext", nullable: true),
                    Zipcode = table.Column<string>(type: "longtext", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsExpired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionAssignments",
                columns: table => new
                {
                    PermissionAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionAssignments", x => x.PermissionAssignmentId);
                    table.ForeignKey(
                        name: "FK_PermissionAssignments_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionAssignments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleAssignments",
                columns: table => new
                {
                    RoleAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HotelBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignments", x => x.RoleAssignmentId);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roster",
                columns: table => new
                {
                    RosterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roster", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_Roster_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roster_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPasswordResets",
                columns: table => new
                {
                    UserPasswordResetsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "longtext", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsEmailSent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswordResets", x => x.UserPasswordResetsId);
                    table.ForeignKey(
                        name: "FK_UserPasswordResets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "City", "IsActive", "IsCurrent", "Name" },
                values: new object[,]
                {
                    { 1, "Dublin 01", "Dublin", true, 1, "The Wangchuks Hotel, Dublin" },
                    { 2, "Cork 01", "Cork", true, 0, "The Wangchuks Hotel, Cork" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "CreatedAt", "Description", "HotelBranchId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9725), "Permission to add a new role to a branch", 1, "admin:role:add" },
                    { 2, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9730), "Permission to view a role", 1, "admin:role:view" },
                    { 3, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9732), "Permission to edit a role", 1, "admin:role:edit" },
                    { 4, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9735), "Permission to delete a role", 1, "admin:role:delete" },
                    { 5, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9737), "Permission to add a permission", 1, "admin:permission:add" },
                    { 6, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9741), "Permission to view a permission", 1, "admin:permission:view" },
                    { 7, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9743), "Permission to edit a permission", 1, "admin:permission:edit" },
                    { 8, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9745), "Permission to delete a permission", 1, "admin:permission:delete" },
                    { 9, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9747), "Permission to add a user", 1, "admin:user:add" },
                    { 10, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9750), "Permission to view a user", 1, "admin:user:view" },
                    { 11, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9754), "Permission to add a user", 1, "admin:user:edit" },
                    { 12, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9756), "Permission to add a user", 1, "admin:user:delete" },
                    { 13, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9758), "Permission to add a visitor", 1, "admin:visitor:add" },
                    { 14, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9760), "Permission to view a visitor", 1, "admin:visitor:view" },
                    { 15, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9762), "Permission to edit a visitor", 1, "admin:visitor:edit" },
                    { 16, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9764), "Permission to delete a visitor", 1, "admin:visitor:delete" },
                    { 17, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9766), "All Permissions", 1, "superadmin" },
                    { 18, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9770), "Permission to add a visitor booking", 1, "frontdesk:booking:add" },
                    { 19, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9772), "Permission to view a visitor booking", 1, "frontdesk:booking:view" },
                    { 20, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9774), "Permission to edit a visitor booking", 1, "frontdesk:booking:edit" },
                    { 21, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9776), "Permission to delete a visitor booking", 1, "frontdesk:booking:delete" },
                    { 22, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9777), "Permission to approve a visitor booking", 1, "frontdesk:booking:approve" },
                    { 23, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9779), "Permission to decline a visitor booking", 1, "frontdesk:booking:decline" },
                    { 24, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9781), "Permission to add a visitor", 1, "frontdesk:visior:add" },
                    { 25, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9783), "Permission to view a visitor", 1, "frontdesk:visior:view" },
                    { 26, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9785), "Permission to edit a visitor", 1, "frontdesk:visior:edit" },
                    { 27, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9787), "Permission to delete a visitor", 1, "frontdesk:visior:delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "HotelBranchId", "IsDeleted", "Name", "ShortName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9658), "System", null, null, "Has all the Permissions", 1, false, "Super Admin", "SuperAdmin", null, null },
                    { 2, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9668), "System", null, null, "Has all the root permissions", 1, false, "Admin", "Admin", null, null },
                    { 3, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9671), "System", null, null, "Manager of the Front Desk Department", 1, false, "Front Desk Manager", "FDManager", null, null },
                    { 4, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9677), "System", null, null, "Assistant staff of the Front Desk Department", 1, false, "Front Desk Assistant", "FDAssistant", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddressLine1", "AddressLine2", "City", "Country", "CreatedAt", "CreatedBy", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "ExpiredAt", "ExpiryDate", "FirstName", "Gender", "Guid", "HotelBranchId", "IsActive", "IsDeleted", "IsEmailVerified", "IsExpired", "LastName", "MiddleName", "Password", "Phone", "State", "UpdatedAt", "UpdatedBy", "UserName", "Zipcode" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(297), "System", null, null, null, "namblyakshay@gmail.com", null, null, "Akshay", null, new Guid("1cfc398c-325a-4749-b95a-4bf5dbc0c141"), 1, true, false, true, false, "Nambly", "Mohanan", "Test1234", "12345", null, null, null, "akshayn", null },
                    { 2, null, null, null, null, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(313), "System", null, null, null, "chaitraumesh.96@gmail.com", null, null, "Chaitra", null, new Guid("8ae5da68-2812-4853-9a24-9660ff424f44"), 1, true, false, true, false, "Umesh", "", "Test1234", "123456", null, null, null, "chaitrau", null },
                    { 3, null, null, null, null, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(319), "System", null, null, null, "jittythomas774@gmail.com", null, null, "Jitty", null, new Guid("988f6586-50d3-4f12-b7b7-eb99e5873d2c"), 1, true, false, true, false, "Thomas", "", "Test1234", "123457", null, null, null, "jittyt", null },
                    { 4, null, null, null, null, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(325), "System", null, null, null, "robinssojan26@gmail.com", null, null, "Robins", null, new Guid("e9d70881-5ec6-4c40-99e1-a3eb6304a2a9"), 1, true, false, true, false, "Sojan", "", "Test1234", "123458", null, null, null, "robinss", null },
                    { 5, null, null, null, null, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(330), "System", null, null, null, "test.admin@gmail.com", null, null, "Super", null, new Guid("1f92d770-64bd-483a-9422-f81581e4deb0"), 1, true, false, true, false, "Admin", "", "Test1234", "123459", null, null, null, "superAdmin", null }
                });

            migrationBuilder.InsertData(
                table: "PermissionAssignments",
                columns: new[] { "PermissionAssignmentId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "HotelBranchId", "IsDeleted", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 16, 52, 11, 281, DateTimeKind.Utc).AddTicks(9996), "System", null, null, 1, false, 17, 1 },
                    { 2, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(1), "System", null, null, 1, false, 1, 2 },
                    { 3, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(4), "System", null, null, 1, false, 2, 2 },
                    { 4, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(6), "System", null, null, 1, false, 3, 2 },
                    { 5, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(8), "System", null, null, 1, false, 4, 2 },
                    { 6, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(11), "System", null, null, 1, false, 5, 2 },
                    { 7, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(13), "System", null, null, 1, false, 6, 2 },
                    { 8, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(15), "System", null, null, 1, false, 7, 2 },
                    { 9, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(17), "System", null, null, 1, false, 8, 2 },
                    { 10, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(20), "System", null, null, 1, false, 8, 2 },
                    { 11, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(22), "System", null, null, 1, false, 9, 2 },
                    { 12, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(24), "System", null, null, 1, false, 10, 2 },
                    { 13, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(26), "System", null, null, 1, false, 11, 2 },
                    { 14, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(28), "System", null, null, 1, false, 12, 2 },
                    { 15, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(30), "System", null, null, 1, false, 13, 2 },
                    { 16, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(32), "System", null, null, 1, false, 14, 2 },
                    { 17, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(35), "System", null, null, 1, false, 15, 2 },
                    { 18, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(38), "System", null, null, 1, false, 16, 2 },
                    { 19, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(43), "System", null, null, 1, false, 19, 3 },
                    { 20, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(45), "System", null, null, 1, false, 20, 3 },
                    { 21, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(47), "System", null, null, 1, false, 21, 3 },
                    { 22, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(48), "System", null, null, 1, false, 22, 3 },
                    { 23, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(50), "System", null, null, 1, false, 23, 3 },
                    { 24, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(52), "System", null, null, 1, false, 24, 3 },
                    { 25, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(54), "System", null, null, 1, false, 25, 3 },
                    { 26, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(56), "System", null, null, 1, false, 18, 4 },
                    { 27, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(58), "System", null, null, 1, false, 19, 4 },
                    { 28, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(60), "System", null, null, 1, false, 20, 4 },
                    { 29, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(62), "System", null, null, 1, false, 22, 4 },
                    { 30, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(68), "System", null, null, 1, false, 24, 4 },
                    { 31, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(70), "System", null, null, 1, false, 25, 4 },
                    { 32, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(41), "System", null, null, 1, false, 18, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoleAssignments",
                columns: new[] { "RoleAssignmentId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ExpiredAt", "HotelBranchId", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(471), "System", null, null, null, 1, false, 1, null, null, 5 },
                    { 2, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(476), "System", null, null, null, 1, false, 3, null, null, 1 },
                    { 3, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(479), "System", null, null, null, 1, false, 4, null, null, 2 },
                    { 4, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(481), "System", null, null, null, 1, false, 4, null, null, 3 },
                    { 5, new DateTime(2024, 4, 17, 16, 52, 11, 282, DateTimeKind.Utc).AddTicks(483), "System", null, null, null, 1, false, 3, null, null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionAssignments_PermissionId",
                table: "PermissionAssignments",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionAssignments_RoleId",
                table: "PermissionAssignments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_RoleId",
                table: "RoleAssignments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_UserId",
                table: "RoleAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roster_ShiftId",
                table: "Roster",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Roster_UserId",
                table: "Roster",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswordResets_UserId",
                table: "UserPasswordResets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "PermissionAssignments");

            migrationBuilder.DropTable(
                name: "RoleAssignments");

            migrationBuilder.DropTable(
                name: "Roster");

            migrationBuilder.DropTable(
                name: "UserPasswordResets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
