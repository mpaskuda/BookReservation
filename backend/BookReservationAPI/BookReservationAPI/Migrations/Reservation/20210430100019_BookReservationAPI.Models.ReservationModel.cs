using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReservationAPI.Migrations.Reservation
{
    public partial class BookReservationAPIModelsReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "UserID", "BookID", "ReservationDate" },
                values: new object[] { 1, 1, new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "UserID", "BookID", "ReservationDate" },
                values: new object[] { 2, 2, new DateTime(2010, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
