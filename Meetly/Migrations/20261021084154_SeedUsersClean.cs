using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersClean : Migration
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
                    { 4, "frank", "password123" },
                    { 5, "grace", "password123" },
                    { 6, "heidi", "password123" },
                    { 7, "ivan", "password123" },
                    { 8, "judy", "password123" },
                    { 9, "karl", "password123" }
                });

            migrationBuilder.InsertData(
                table: "Meet",
                columns: new[] { "Id", "HostId", "Place", "Time", "description", "maxCapacity", "title" },
                values: new object[,]
                {
                    { 1, 4, "Conference Room", new DateTime(2026, 11, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Weekly team meeting", 10, "Team Meeting" },
                    { 2, 5, "Zoom", new DateTime(2026, 11, 2, 14, 0, 0, 0, DateTimeKind.Utc), "Kickoff meeting for the new project", 20, "Project Kickoff" },
                    { 3, 6, "Lab 1", new DateTime(2026, 11, 3, 9, 30, 0, 0, DateTimeKind.Utc), "Hands-on workshop on new technology", 3, "Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Meetuser",
                columns: new[] { "AttendesId", "AttendingMeetsId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "maxCapacity",
                table: "Meet");
        }
    }
}
