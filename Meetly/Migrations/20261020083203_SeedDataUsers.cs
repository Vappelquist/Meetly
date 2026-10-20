using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maxCapacity",
                table: "Meet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "stig", "password123" },
                    { 2, "bob", "password123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "maxCapacity",
                table: "Meet");
        }
    }
}
