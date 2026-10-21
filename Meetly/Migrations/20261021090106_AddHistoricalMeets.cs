using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricalMeets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meet",
                columns: new[] { "Id", "HostId", "Place", "Time", "description", "maxCapacity", "title" },
                values: new object[,]
                {
                    { 4, 4, "Main Auditorium", new DateTime(2026, 8, 15, 9, 0, 0, 0, DateTimeKind.Utc), "48-hour prototype challenge and pizza.", 40, "Summer Hackathon 2026" },
                    { 5, 5, "Lab 2", new DateTime(2026, 9, 20, 13, 0, 0, 0, DateTimeKind.Utc), "Deep dive into React frontend and ASP.NET Core Azure hosting.", 15, "React & Azure Workshop" },
                    { 6, 6, "Room 204", new DateTime(2026, 10, 5, 15, 0, 0, 0, DateTimeKind.Utc), "Discussing the UI/UX layout and prototype screens.", 8, "Initial Design Sync" }
                });

            migrationBuilder.InsertData(
                table: "Meetuser",
                columns: new[] { "AttendesId", "AttendingMeetsId" },
                values: new object[,]
                {
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 4 },
                    { 7, 4 },
                    { 8, 5 },
                    { 9, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meet",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
