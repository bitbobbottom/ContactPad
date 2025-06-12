using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactNotePad.Migrations
{
    /// <inheritdoc />
    public partial class UserContactRelationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Contacts",
                newName: "CreatedAt");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1u,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2u,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Contacts",
                newName: "created_at");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1u,
                column: "created_at",
                value: new DateTime(2025, 5, 26, 18, 45, 23, 661, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2u,
                column: "created_at",
                value: new DateTime(2025, 5, 26, 18, 45, 23, 662, DateTimeKind.Utc).AddTicks(1558));
        }
    }
}
