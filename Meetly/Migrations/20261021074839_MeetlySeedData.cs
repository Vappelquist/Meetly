using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class MeetlySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meet",
                columns: new[] { "Id", "HostId", "Place", "Time", "description", "maxCapacity", "title" },
                values: new object[,]
                {
                    { 1, 1, "Conference Room", new DateTime(2026, 10, 21, 9, 48, 38, 600, DateTimeKind.Local).AddTicks(3959), "Weekly team meeting", 10, "Team Meeting" },
                    { 2, 2, "Zoom", new DateTime(2026, 10, 22, 9, 48, 38, 604, DateTimeKind.Local).AddTicks(7945), "Kickoff meeting for the new project", 20, "Project Kickoff" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { 3, "alice", "password123" },
                    { 4, "charlie", "password123" },
                    { 5, "dave", "password123" },
                    { 6, "eve", "password123" }
                });

            migrationBuilder.InsertData(
                table: "Meet",
                columns: new[] { "Id", "HostId", "Place", "Time", "description", "maxCapacity", "title" },
                values: new object[] { 3, 3, "Lab 1", new DateTime(2026, 10, 23, 9, 48, 38, 604, DateTimeKind.Local).AddTicks(8040), "Hands-on workshop on new technology", 3, "Workshop" });

            migrationBuilder.InsertData(
                table: "Meetuser",
                columns: new[] { "AttendesId", "AttendingMeetsId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Meetuser",
                keyColumns: new[] { "AttendesId", "AttendingMeetsId" },
                keyValues: new object[] { 6, 3 });

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
