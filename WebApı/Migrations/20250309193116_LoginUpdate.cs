using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class LoginUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Id",
                value: "c3e6e898-9e59-4402-90a8-264b96e6ecfa");

            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Id",
                value: "76f9d345-5eef-439a-a507-6b95b6f20a21");

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 1,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 31, 16, 324, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 2,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 31, 16, 324, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "019b829e-e389-44f0-aa9c-a4f0bd741830", "AQAAAAIAAYagAAAAEKQaeWl34Na0XT17aK7zv3l2sgPOxmmLSBL7CskCjIC7oOvn71IY4iU3afnnPYhy1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d459a93-8007-43fa-8e07-98d646d86695", "AQAAAAIAAYagAAAAEHmLFPld3FeBSpuqcv+AAxze+GpBTUK5XbA3UPH/GHNkeM8ixF/K0unKY588dXEcWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea8e2d0a-cf1b-4bf4-aa82-b4de50cf675e", "AQAAAAIAAYagAAAAEKawWHufIHPW1/H/aSJzG2c/CMh8sLQaFgIM/XJk92qVkkwSCG7Ri1M+RTyWc9a0bA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Id",
                value: "81223ca2-2ed0-48a2-a454-7f0e4fbfdcee");

            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Id",
                value: "11c4d902-5ee1-4030-a3eb-ded51092abed");

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 1,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 23, 30, 328, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 2,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 23, 30, 328, DateTimeKind.Local).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "4fc5f7eb-d12b-4148-adfb-2f4f80f01730", "123456", "hashed_password_1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "734a5a33-30d8-40e9-84b6-6b95bc964ec6", "123456", "string" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "37e698e8-c12a-43a3-bd61-1beccc00b62a", "123456", "string" });
        }
    }
}
