using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class ForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_Client_ID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_Psychologist_ID",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_Client_ID",
                table: "Appointments",
                column: "Client_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_Psychologist_ID",
                table: "Appointments",
                column: "Psychologist_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_Client_ID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_Psychologist_ID",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_Client_ID",
                table: "Appointments",
                column: "Client_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_Psychologist_ID",
                table: "Appointments",
                column: "Psychologist_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
