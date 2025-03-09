using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Id",
                value: "f5f3ef61-031c-4e8c-8299-969fb07ff061");

            migrationBuilder.UpdateData(
                table: "AssignRole",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Id",
                value: "43d297c3-c20c-4bba-9fa9-dfeda4210128");

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 1,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 31, 55, 378, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 2,
                column: "RentalDate",
                value: new DateTime(2025, 3, 9, 22, 31, 55, 378, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14d0ab32-12a3-491b-acf6-4c00a2a986fc", "AQAAAAIAAYagAAAAEBtcEWsh0gBXANqEqZh4rxGkerzuNS4P2SgzJv867Qsb2rmmulVymlb6phCZmJusCw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d600cba-a85a-40ea-b20f-afe2543dc2b4", "AQAAAAIAAYagAAAAENyZG3zC0PruVJ6Cb/OGiICmygy2rGArHwBUkoWkERN5eqltH8pBWmehthVCoFDwXQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99550c3a-aa73-419f-ad41-cf1b3a390834", "AQAAAAIAAYagAAAAEP790cO27Q4lkv1nTJl19SrcIl/SyiM9a58ulekcmqlrJwSrwB1O94BmCwi3/6ilFQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
