using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDbWithTestModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e67e6360-970f-40e2-95f4-1ee7e0d24c07", 0, "ae1a0596-7095-409e-b76e-7710e7bc244e", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEHJr40paNDhDfRuDkFgmgfVMXL2reiZEYmambjF4sOUOabJC0kDCWyqaaY/vD9RKow==", null, false, "092eb485-2a21-4396-98d1-1e68b46c36fd", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 19, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4653), "Implement better styling for all public pages", "e67e6360-970f-40e2-95f4-1ee7e0d24c07", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 9, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4683), "Create android client app for the TaskBoard RESTful API", "e67e6360-970f-40e2-95f4-1ee7e0d24c07", "Android Client App", null },
                    { 3, 2, new DateTime(2024, 1, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4687), "Create Windows Forms desktop app client app for the TaskBoard RESTful API", "e67e6360-970f-40e2-95f4-1ee7e0d24c07", "Desktop Client App", null },
                    { 4, 3, new DateTime(2023, 2, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4689), "Implement [Create Task] page for adding new tasks", "e67e6360-970f-40e2-95f4-1ee7e0d24c07", "Create Tasks", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e67e6360-970f-40e2-95f4-1ee7e0d24c07");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
