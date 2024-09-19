using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaReservationMain.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUserIdtoStringinSeatReserv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId1",
                table: "SeatReservations");

            migrationBuilder.DropIndex(
                name: "IX_SeatReservations_AppUserId1",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "SeatReservations");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "SeatReservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_AppUserId",
                table: "SeatReservations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId",
                table: "SeatReservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId",
                table: "SeatReservations");

            migrationBuilder.DropIndex(
                name: "IX_SeatReservations_AppUserId",
                table: "SeatReservations");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "SeatReservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "SeatReservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_AppUserId1",
                table: "SeatReservations",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatReservations_AspNetUsers_AppUserId1",
                table: "SeatReservations",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
