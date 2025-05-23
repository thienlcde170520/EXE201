using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class FixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_ProfilePictureUrl",
                table: "AspNetUsers");
        }
    }
}
