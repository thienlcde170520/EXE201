using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePicture", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "067bf495-ca7f-4812-97a8-5d61d0229190", 0, "Cần Thơ, Việt Nam", "e1ef7f83-f993-4b5d-aa89-a085c4fee7e6", "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, null, "~image/Doctor/Kim_Nguan.png", "b928d1fa-1ae2-4d4b-b186-4ce73181df67", false, "Kim Nguyễn" },
                    { "4a0c8e83-3844-4be4-9f77-9b87443abc21", 0, "Hà Nội, Việt Nam", "28d4da1f-9f97-477e-8295-539427f26517", "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, null, "~image/Doctor/Dung_Le.png", "b67a5195-8c32-4018-a6d5-5d222f22f90d", false, "Dung Lê" },
                    { "9e31d33a-f266-4320-b7b2-df2fcb3dfe1a", 0, "Đà Nẵng, Việt Nam", "e8af0820-78fb-451d-9d38-731d2d7182a6", "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, null, "~image/Doctor/Ha_Le.png", "95028aa7-118f-4f34-9cbf-243b73d0d74c", false, "Hà Lê" },
                    { "c1b68810-e4d9-43e4-a2b3-cb15c1ed3da4", 0, "HCM, Việt Nam", "2eb2c2f6-ca4c-465c-a946-4fb6252e6f9b", "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, null, "~image/Doctor/Van_Thang.png", "acc3a7f0-5ac6-4557-9747-49ba29626236", false, "Lê Văn Thắng" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "067bf495-ca7f-4812-97a8-5d61d0229190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a0c8e83-3844-4be4-9f77-9b87443abc21");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e31d33a-f266-4320-b7b2-df2fcb3dfe1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1b68810-e4d9-43e4-a2b3-cb15c1ed3da4");
        }
    }
}
