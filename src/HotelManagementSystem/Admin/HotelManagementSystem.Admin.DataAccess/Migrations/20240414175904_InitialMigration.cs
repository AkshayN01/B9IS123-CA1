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
                    { 1, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1819), "Permission to add a new role to a branch", 1, "admin:role:add" },
                    { 2, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1824), "Permission to view a role", 1, "admin:role:view" },
                    { 3, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1827), "Permission to edit a role", 1, "admin:role:edit" },
                    { 4, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1829), "Permission to delete a role", 1, "admin:role:delete" },
                    { 5, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1832), "Permission to add a permission", 1, "admin:permission:add" },
                    { 6, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1842), "Permission to view a permission", 1, "admin:permission:view" },
                    { 7, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1845), "Permission to edit a permission", 1, "admin:permission:edit" },
                    { 8, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1847), "Permission to delete a permission", 1, "admin:permission:delete" },
                    { 9, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1849), "Permission to add a user", 1, "admin:user:add" },
                    { 10, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1853), "Permission to view a user", 1, "admin:user:view" },
                    { 11, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1855), "Permission to add a user", 1, "admin:user:edit" },
                    { 12, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1858), "Permission to add a user", 1, "admin:user:delete" },
                    { 13, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1860), "Permission to add a visitor", 1, "admin:visitor:add" },
                    { 14, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1861), "Permission to view a visitor", 1, "admin:visitor:view" },
                    { 15, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1864), "Permission to edit a visitor", 1, "admin:visitor:edit" },
                    { 16, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1866), "Permission to delete a visitor", 1, "admin:visitor:delete" },
                    { 17, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1868), "All Permissions", 1, "superadmin" },
                    { 18, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1872), "Permission to add a visitor booking", 1, "frontdesk:booking:add" },
                    { 19, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1874), "Permission to view a visitor booking", 1, "frontdesk:booking:view" },
                    { 20, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1877), "Permission to edit a visitor booking", 1, "frontdesk:booking:edit" },
                    { 21, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1879), "Permission to delete a visitor booking", 1, "frontdesk:booking:delete" },
                    { 22, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1881), "Permission to approve a visitor booking", 1, "frontdesk:booking:approve" },
                    { 23, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1883), "Permission to decline a visitor booking", 1, "frontdesk:booking:decline" },
                    { 24, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1886), "Permission to add a visitor", 1, "frontdesk:visior:add" },
                    { 25, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1888), "Permission to view a visitor", 1, "frontdesk:visior:view" },
                    { 26, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1890), "Permission to edit a visitor", 1, "frontdesk:visior:edit" },
                    { 27, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1892), "Permission to delete a visitor", 1, "frontdesk:visior:delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "HotelBranchId", "IsDeleted", "Name", "ShortName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1658), "System", null, null, "Has all the Permissions", 1, false, "Super Admin", "SuperAdmin", null, null },
                    { 2, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1675), "System", null, null, "Has all the root permissions", 1, false, "Admin", "Admin", null, null },
                    { 3, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1678), "System", null, null, "Manager of the Front Desk Department", 1, false, "Front Desk Manager", "FDManager", null, null },
                    { 4, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(1682), "System", null, null, "Assistant staff of the Front Desk Department", 1, false, "Front Desk Assistant", "FDAssistant", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddressLine1", "AddressLine2", "City", "Country", "CreatedAt", "CreatedBy", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "ExpiredAt", "ExpiryDate", "FirstName", "Gender", "Guid", "HotelBranchId", "IsActive", "IsDeleted", "IsEmailVerified", "IsExpired", "LastName", "MiddleName", "Password", "Phone", "State", "UpdatedAt", "UpdatedBy", "UserName", "Zipcode" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3291), "System", null, null, null, "namblyakshay@gmail.com", null, null, "Akshay", null, new Guid("a563076f-e2b6-475c-b56f-2bbaacfa89d6"), 1, true, false, true, false, "Nambly", "Mohanan", "Test1234", "12345", null, null, null, "akshayn", null },
                    { 2, null, null, null, null, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3301), "System", null, null, null, "chaitraumesh.96@gmail.com", null, null, "Chaitra", null, new Guid("e0fa9e16-0e4e-4af3-8bdb-175d3fe6c405"), 1, true, false, true, false, "Umesh", "", "Test1234", "123456", null, null, null, "chaitrau", null },
                    { 3, null, null, null, null, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3307), "System", null, null, null, "jittythomas774@gmail.com", null, null, "Jitty", null, new Guid("3bd3f833-7ca3-4366-8ca1-6e61b8b4a631"), 1, true, false, true, false, "Thomas", "", "Test1234", "123457", null, null, null, "jittyt", null },
                    { 4, null, null, null, null, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3313), "System", null, null, null, "robinssojan26@gmail.com", null, null, "Robins", null, new Guid("418a4548-89a2-491a-bc06-6c5c44e99bdd"), 1, true, false, true, false, "Sojan", "", "Test1234", "123458", null, null, null, "robinss", null },
                    { 5, null, null, null, null, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3318), "System", null, null, null, "test.admin@gmail.com", null, null, "Super", null, new Guid("6c0f482d-ce4d-4488-808d-017926eda659"), 1, true, false, true, false, "Admin", "", "Test1234", "123459", null, null, null, "superAdmin", null }
                });

            migrationBuilder.InsertData(
                table: "PermissionAssignments",
                columns: new[] { "PermissionAssignmentId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "HotelBranchId", "IsDeleted", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2076), "System", null, null, 1, false, 17, 1 },
                    { 2, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2081), "System", null, null, 1, false, 1, 2 },
                    { 3, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2084), "System", null, null, 1, false, 2, 2 },
                    { 4, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2086), "System", null, null, 1, false, 3, 2 },
                    { 5, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2089), "System", null, null, 1, false, 4, 2 },
                    { 6, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2092), "System", null, null, 1, false, 5, 2 },
                    { 7, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2095), "System", null, null, 1, false, 6, 2 },
                    { 8, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2097), "System", null, null, 1, false, 7, 2 },
                    { 9, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2100), "System", null, null, 1, false, 8, 2 },
                    { 10, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2104), "System", null, null, 1, false, 8, 2 },
                    { 11, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2106), "System", null, null, 1, false, 9, 2 },
                    { 12, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2108), "System", null, null, 1, false, 10, 2 },
                    { 13, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2110), "System", null, null, 1, false, 11, 2 },
                    { 14, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2113), "System", null, null, 1, false, 12, 2 },
                    { 15, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2115), "System", null, null, 1, false, 13, 2 },
                    { 16, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2117), "System", null, null, 1, false, 14, 2 },
                    { 17, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2119), "System", null, null, 1, false, 15, 2 },
                    { 18, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2123), "System", null, null, 1, false, 16, 2 },
                    { 19, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2126), "System", null, null, 1, false, 19, 3 },
                    { 20, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2128), "System", null, null, 1, false, 20, 3 },
                    { 21, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2130), "System", null, null, 1, false, 21, 3 },
                    { 22, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2132), "System", null, null, 1, false, 22, 3 },
                    { 23, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2134), "System", null, null, 1, false, 23, 3 },
                    { 24, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2975), "System", null, null, 1, false, 24, 3 },
                    { 25, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2982), "System", null, null, 1, false, 25, 3 },
                    { 26, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2984), "System", null, null, 1, false, 18, 4 },
                    { 27, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2987), "System", null, null, 1, false, 19, 4 },
                    { 28, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2990), "System", null, null, 1, false, 20, 4 },
                    { 29, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2992), "System", null, null, 1, false, 22, 4 },
                    { 30, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2994), "System", null, null, 1, false, 24, 4 },
                    { 31, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2997), "System", null, null, 1, false, 25, 4 },
                    { 32, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(2124), "System", null, null, 1, false, 18, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoleAssignments",
                columns: new[] { "RoleAssignmentId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ExpiredAt", "HotelBranchId", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3366), "System", null, null, null, 1, false, 1, null, null, 5 },
                    { 2, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3372), "System", null, null, null, 1, false, 3, null, null, 1 },
                    { 3, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3375), "System", null, null, null, 1, false, 4, null, null, 2 },
                    { 4, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3378), "System", null, null, null, 1, false, 4, null, null, 3 },
                    { 5, new DateTime(2024, 4, 14, 17, 59, 4, 290, DateTimeKind.Utc).AddTicks(3380), "System", null, null, null, 1, false, 3, null, null, 4 }
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
