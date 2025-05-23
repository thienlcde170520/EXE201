using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class podcastCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePicture", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3678c375-ad66-4990-b653-7d67e82da258", 0, "Cần Thơ, Việt Nam", "e62e1844-6c9f-460a-8165-250ccdbfbc98", "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, null, "~image/Doctor/Kim_Nguan.png", "8ed56b6e-712d-4552-a9e0-a3c4fd0fdebb", false, "Kim Nguyễn" },
                    { "5b5fedaf-92dd-48dc-9ef9-0dfabb398605", 0, "Đà Nẵng, Việt Nam", "518db135-9d9a-4fbc-8049-70a4b384ac23", "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "thienlc2105@gamil.com", false, "6 years", false, null, "Thien Le", null, null, null, "0933555777", null, false, 750000m, null, "~image/Doctor/download.jfif", "4d0daa78-ab92-4cad-8caa-cf86b4829832", false, "Thien Le" },
                    { "5fe5ae22-b3ed-4ee5-ae44-b5a305588346", 0, "Đà Nẵng, Việt Nam", "3b36a2bc-6fca-498d-99cb-88f8fc591d5c", "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, null, "~image/Doctor/Ha_Le.png", "4ee29fde-175e-4ab0-be37-caf1129ede8c", false, "Hà Lê" },
                    { "b82425b2-fcd0-4a69-ad88-b07d2bb0f92b", 0, "HCM, Việt Nam", "8415eb2c-3631-4ffa-a79f-4fe33f60dcb7", "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, null, "~image/Doctor/Van_Thang.png", "656e01c1-6008-425d-be5b-42bffa9e9334", false, "Lê Văn Thắng" },
                    { "e377c76e-9eed-4278-a00f-4aa458c531f6", 0, "Hà Nội, Việt Nam", "a20c1a3f-8dce-416c-abc2-b9f27ee9d808", "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, null, "~image/Doctor/Dung_Le.png", "750f61d3-509d-425b-8886-1900e77ed15e", false, "Dung Lê" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3678c375-ad66-4990-b653-7d67e82da258");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b5fedaf-92dd-48dc-9ef9-0dfabb398605");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fe5ae22-b3ed-4ee5-ae44-b5a305588346");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b82425b2-fcd0-4a69-ad88-b07d2bb0f92b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e377c76e-9eed-4278-a00f-4aa458c531f6");

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
    }
}
