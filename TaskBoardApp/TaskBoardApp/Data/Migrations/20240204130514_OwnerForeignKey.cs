using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class OwnerForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e67e6360-970f-40e2-95f4-1ee7e0d24c07");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a8f30222-4b86-4400-a70e-f4a53d58cdd9", 0, "3d2395e0-8171-4049-8644-b82e4130ea8a", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEKCnxVPqgctZG5+8osPUnWsgKAtkg4AmSr94hL6iIx2weeDshBNWYKW4Zzy7JHrLMQ==", null, false, "e05fcd88-3993-4068-9ea2-42a77d59d09b", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 7, 19, 15, 5, 14, 239, DateTimeKind.Local).AddTicks(3556), "a8f30222-4b86-4400-a70e-f4a53d58cdd9" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 4, 15, 5, 14, 239, DateTimeKind.Local).AddTicks(3585), "a8f30222-4b86-4400-a70e-f4a53d58cdd9" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 1, 4, 15, 5, 14, 239, DateTimeKind.Local).AddTicks(3588), "a8f30222-4b86-4400-a70e-f4a53d58cdd9" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 4, 15, 5, 14, 239, DateTimeKind.Local).AddTicks(3590), "a8f30222-4b86-4400-a70e-f4a53d58cdd9" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8f30222-4b86-4400-a70e-f4a53d58cdd9");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e67e6360-970f-40e2-95f4-1ee7e0d24c07", 0, "ae1a0596-7095-409e-b76e-7710e7bc244e", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEHJr40paNDhDfRuDkFgmgfVMXL2reiZEYmambjF4sOUOabJC0kDCWyqaaY/vD9RKow==", null, false, "092eb485-2a21-4396-98d1-1e68b46c36fd", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 7, 19, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4653), "e67e6360-970f-40e2-95f4-1ee7e0d24c07" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4683), "e67e6360-970f-40e2-95f4-1ee7e0d24c07" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 1, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4687), "e67e6360-970f-40e2-95f4-1ee7e0d24c07" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 4, 13, 27, 5, 307, DateTimeKind.Local).AddTicks(4689), "e67e6360-970f-40e2-95f4-1ee7e0d24c07" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
