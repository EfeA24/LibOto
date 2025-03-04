using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApı.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-Fiction" },
                    { 3, "Science" },
                    { 4, "History" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "f0cb7783-f122-4c33-b59c-d63627582709", "john.doe@example.com", true, "John Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "hashed_password_1", null, false, "stamp_1", false, "john.doe" },
                    { "2", 0, "ba17a789-0b46-4476-8d00-3976615c8af3", "jane.smith@example.com", true, "Jane Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "hashed_password_2", null, false, "stamp_2", false, "jane.smith" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "DatePublished", "Description", "IsRented", "Title", "TotalPages" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", 1, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A novel set in the 1920s.", false, "The Great Gatsby", 180 },
                    { 2, "Yuval Noah Harari", 2, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A book about the history of humankind.", false, "Sapiens: A Brief History of Humankind", 443 },
                    { 3, "Stephen Hawking", 3, new DateTime(1988, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A popular-science book on cosmology.", false, "A Brief History of Time", 256 },
                    { 4, "Anne Frank", 4, new DateTime(1947, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The diary of a Jewish girl during World War II.", false, "The Diary of a Young Girl", 283 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentId", "BookId", "IsApproved", "RentalDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2025, 3, 5, 2, 41, 33, 103, DateTimeKind.Local).AddTicks(8868), null, "1" },
                    { 2, 2, true, new DateTime(2025, 3, 5, 2, 41, 33, 103, DateTimeKind.Local).AddTicks(8879), null, "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
