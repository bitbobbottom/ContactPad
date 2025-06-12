using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactNotePad.Migrations
{
    /// <inheritdoc />
    public partial class unsignedIsShitInCHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nickname", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "admin", "admin" },
                    { 2, "user@gmail.com", "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedAt", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "Test contact John", "john.doe@example.com", "John", "Doe", "123-456-7890", 1 },
                    { 2, "456 Oak Ave", new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "Test contact Jane", "jane.doe@example.com", "Jane", "Doe", "987-654-3210", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nickname", "PasswordHash" },
                values: new object[,]
                {
                    { 1u, "admin@gmail.com", "admin", "admin" },
                    { 2u, "user@gmail.com", "user", "user" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedAt", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1u, "123 Main St", new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "Test contact John", "john.doe@example.com", "John", "Doe", "123-456-7890", 1u },
                    { 2u, "456 Oak Ave", new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "Test contact Jane", "jane.doe@example.com", "Jane", "Doe", "987-654-3210", 1u }
                });
        }
    }
}
