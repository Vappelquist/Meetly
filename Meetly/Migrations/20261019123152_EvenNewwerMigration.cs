using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meetly.Migrations
{
    /// <inheritdoc />
    public partial class EvenNewwerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meet_User_HostId",
                        column: x => x.HostId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetuser",
                columns: table => new
                {
                    AttendesId = table.Column<int>(type: "int", nullable: false),
                    AttendingMeetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetuser", x => new { x.AttendesId, x.AttendingMeetsId });
                    table.ForeignKey(
                        name: "FK_Meetuser_Meet_AttendingMeetsId",
                        column: x => x.AttendingMeetsId,
                        principalTable: "Meet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetuser_User_AttendesId",
                        column: x => x.AttendesId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meet_HostId",
                table: "Meet",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetuser_AttendingMeetsId",
                table: "Meetuser",
                column: "AttendingMeetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetuser");

            migrationBuilder.DropTable(
                name: "Meet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
