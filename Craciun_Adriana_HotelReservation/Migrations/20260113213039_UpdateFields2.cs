using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Craciun_Adriana_HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
