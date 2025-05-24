using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class SecondData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "226f1c77-954b-4b94-9033-58ef314f782d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35206a61-dad7-4e1e-a8e3-c675bc914c21");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c90bea7-2800-4d45-89cb-052f788d93eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8050239a-1b5f-4414-b89f-c16e6b4a3331");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86a5fc91-acf4-448b-b1ef-ec4dce369363");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "CertificateUrl", "ConcurrencyStamp", "DateOfBirth", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "226f1c77-954b-4b94-9033-58ef314f782d", 0, "Đà Nẵng, Việt Nam", null, "264b34af-e286-4da5-9a59-9846133f38f5", null, "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", "Unspecified", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, "~image/Doctor/Ha_Le.png", "89b282f6-11e3-40aa-a215-f7413e15c1a4", false, "Hà Lê" },
                    { "35206a61-dad7-4e1e-a8e3-c675bc914c21", 0, "Đà Nẵng, Việt Nam", null, "43d8a88f-57d4-4405-abc4-7ea9265b0004", null, "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "thienlc2105@gamil.com", false, "6 years", "Unspecified", false, null, "Thien Le", null, null, null, "0933555777", null, false, 750000m, "~image/Doctor/download.jfif", "abdf640b-a7e4-47f4-87c4-902e93c45257", false, "Thien Le" },
                    { "7c90bea7-2800-4d45-89cb-052f788d93eb", 0, "HCM, Việt Nam", null, "436cd40f-6a9c-4284-a4ed-4b1c03ac7287", null, "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", "Unspecified", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, "~image/Doctor/Van_Thang.png", "bd68cb1e-6860-4046-b2d4-e949b6dd9c4d", false, "Lê Văn Thắng" },
                    { "8050239a-1b5f-4414-b89f-c16e6b4a3331", 0, "Cần Thơ, Việt Nam", null, "7b88beb8-6cbc-4b73-82e4-036017801810", null, "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", "Unspecified", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, "~image/Doctor/Kim_Nguan.png", "0de38ac0-a34f-4f82-bf1e-5dd89411979a", false, "Kim Nguyễn" },
                    { "86a5fc91-acf4-448b-b1ef-ec4dce369363", 0, "Hà Nội, Việt Nam", null, "1bb9de76-092f-48ca-902b-e000674bde80", null, "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", "Unspecified", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, "~image/Doctor/Dung_Le.png", "f43443ea-9366-4d51-9f79-a40c1fb29157", false, "Dung Lê" }
                });
        }
    }
}
