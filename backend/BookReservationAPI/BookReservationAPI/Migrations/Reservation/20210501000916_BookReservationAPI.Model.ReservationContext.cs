using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReservationAPI.Migrations.Reservation
{
    public partial class BookReservationAPIModelReservationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookID", "ReservationDate", "UserID" },
                values: new object[] { 1, 1, new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookID", "ReservationDate", "UserID" },
                values: new object[] { 2, 2, new DateTime(2010, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
