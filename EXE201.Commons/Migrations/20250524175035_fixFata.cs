using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class fixFata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6eda8d88-3a85-4add-a3ba-54778f010f64");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74d1dc19-94a7-407f-8b0c-12a1a8f731bc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bbaf061-9504-44aa-9862-a209d93e00df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0827ece-ae6a-4d87-aa0a-9d9635b751d4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "CertificateUrl", "ConcurrencyStamp", "DateOfBirth", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6eda8d88-3a85-4add-a3ba-54778f010f64", 0, "Đà Nẵng, Việt Nam", null, "cd29f9f4-5557-49b8-aa6f-0c67f2e53a1c", null, "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", "Unspecified", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, "~image/Doctor/Ha_Le.png", "79320c68-945b-4f35-a40a-471c38bac393", false, "Hà Lê" },
                    { "74d1dc19-94a7-407f-8b0c-12a1a8f731bc", 0, "Hà Nội, Việt Nam", null, "5fc3ffba-4dd2-4925-bae5-5fd2e9893121", null, "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", "Unspecified", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, "~image/Doctor/Dung_Le.png", "4a7b1f19-4e1f-414c-b18b-735d0276569d", false, "Dung Lê" },
                    { "9bbaf061-9504-44aa-9862-a209d93e00df", 0, "Cần Thơ, Việt Nam", null, "fdba479a-0aac-44c1-8aec-2ba4a594e669", null, "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", "Unspecified", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, "~image/Doctor/Kim_Nguan.png", "7add8dca-b419-41bf-a0cc-bc6f8cc1f7a3", false, "Kim Nguyễn" },
                    { "a0827ece-ae6a-4d87-aa0a-9d9635b751d4", 0, "HCM, Việt Nam", null, "ad2f2218-4692-4d80-8e52-b18fa088589c", null, "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", "Unspecified", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, "~image/Doctor/Van_Thang.png", "6b109524-530c-48a5-ab71-10e366600b79", false, "Lê Văn Thắng" }
                });
        }
    }
}
