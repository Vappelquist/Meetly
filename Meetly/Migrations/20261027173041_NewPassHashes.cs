using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class NewPassHashes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENK5j8c3QYmP5pIu0q7tY1v8z2x4w6y8u0o2i4a6s8d0f2g4h6j8k0l2m4==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENK5j8c3QYmP5pIu0q7tY1v8z2x4w6y8u0o2i4a6s8d0f2g4h6j8k0l2m4==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENK5j8c3QYmP5pIu0q7tY1v8z2x4w6y8u0o2i4a6s8d0f2g4h6j8k0l2m4==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENK5j8c3QYmP5pIu0q7tY1v8z2x4w6y8u0o2i4a6s8d0f2g4h6j8k0l2m4==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELgB3s8m3R8i5b3l/jR8O2yG9QvQ3eZ8wY8b4z7k1v2x3y4z5a6b7c8d9e0f==");
        }
    }
}
