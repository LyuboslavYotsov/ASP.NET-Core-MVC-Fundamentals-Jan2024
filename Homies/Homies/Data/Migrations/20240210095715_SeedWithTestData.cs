using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homies.Data.Migrations
{
    public partial class SeedWithTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "feb0188c-0a34-44f8-9d12-d035b9c46e51", 0, "87b5e4c3-c2c2-4443-a877-09650a045600", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEPLCKPuc9SB/3lAaSNbZL0dqZTIsnUrgJf6oPaN46sRDfECe2qbeuNtHGyFyvDTHjg==", null, false, "848ef105-b7dc-4e34-9eaf-acea4353a7cd", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedOn", "Description", "End", "Name", "OrganiserId", "Start", "TypeId" },
                values: new object[] { 1, new DateTime(2024, 2, 10, 11, 57, 15, 376, DateTimeKind.Local).AddTicks(1860), "Testing the event description", new DateTime(2024, 2, 13, 11, 57, 15, 376, DateTimeKind.Local).AddTicks(1893), "Test Event", "feb0188c-0a34-44f8-9d12-d035b9c46e51", new DateTime(2024, 2, 11, 11, 57, 15, 376, DateTimeKind.Local).AddTicks(1892), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "feb0188c-0a34-44f8-9d12-d035b9c46e51");
        }
    }
}
