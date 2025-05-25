using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class AddMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d1bae59-d7a6-41f3-ba63-c7d128cceb8e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35c1bb90-6703-4ea8-bb5e-cc9db8c7af13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a821b815-b710-435c-b123-b19ed92537cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da16d6b5-f2a1-4e95-a900-1ec62fae7cd0");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "CertificateUrl", "ConcurrencyStamp", "DateOfBirth", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2d1bae59-d7a6-41f3-ba63-c7d128cceb8e", 0, "Đà Nẵng, Việt Nam", null, "64e3dba9-2854-40a6-a2da-ea0b02951191", null, "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", "Unspecified", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, "~image/Doctor/Ha_Le.png", "a34aa329-82f4-4996-9883-413c644d47aa", false, "Hà Lê" },
                    { "35c1bb90-6703-4ea8-bb5e-cc9db8c7af13", 0, "Hà Nội, Việt Nam", null, "3a307517-b433-41e7-8201-0318fac3bfca", null, "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", "Unspecified", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, "~image/Doctor/Dung_Le.png", "e6e05c75-b4f7-4b50-ae6a-d62870e5e045", false, "Dung Lê" },
                    { "a821b815-b710-435c-b123-b19ed92537cf", 0, "HCM, Việt Nam", null, "205e4814-065e-483c-a56a-a1fb7232dd88", null, "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", "Unspecified", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, "~image/Doctor/Van_Thang.png", "674b0682-abb1-4891-9a9f-0274bd1f5d4c", false, "Lê Văn Thắng" },
                    { "da16d6b5-f2a1-4e95-a900-1ec62fae7cd0", 0, "Cần Thơ, Việt Nam", null, "9e35d60f-a3e7-42d8-8fc4-75dc5bd07629", null, "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", "Unspecified", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, "~image/Doctor/Kim_Nguan.png", "79ec428c-95d3-4e34-98c3-ade5d3b37d46", false, "Kim Nguyễn" }
                });
        }
    }
}
