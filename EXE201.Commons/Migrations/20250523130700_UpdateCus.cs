using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXE201.Commons.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CertificateUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Degree", "Description", "Discriminator", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Price", "ProfilePicture", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04a83a10-81ca-4043-b1f5-5b219e333880", 0, "Đà Nẵng, Việt Nam", "77f662fa-4cf1-4f47-9b38-6c7942186194", "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "thienlc2105@gamil.com", false, "6 years", false, null, "Thien Le", null, null, null, "0933555777", null, false, 750000m, null, "~image/Doctor/download.jfif", "7011c39a-af2b-40bf-a06e-06ba78352399", false, "Thien Le" },
                    { "28a557ab-010d-4e49-9e48-7a6bef3fd1a1", 0, "Cần Thơ, Việt Nam", "53707ca2-fee4-434b-9706-720ef68d22a6", "~image/Degree/cunhantamly.jpg", "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.", "Psychologist", "KimNguyen123@gamil.com", false, "6 years", false, null, "Kim Nguyễn", null, null, null, "0933555777", null, false, 750000m, null, "~image/Doctor/Kim_Nguan.png", "6d4cf21a-22ff-44bb-91aa-de0af25c9567", false, "Kim Nguyễn" },
                    { "4d1310f1-855b-4be1-93be-e2aaaee741f3", 0, "Hà Nội, Việt Nam", "1e1f9a58-2017-4cc8-8909-c611f75d4c82", "~image/Degree/cunhantamly.jpg", "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.", "Psychologist", "Dungle123@gamil.com", false, "7 years", false, null, "Dung Lê", null, null, null, "0987654321", null, false, 850000m, null, "~image/Doctor/Dung_Le.png", "562b70fa-c629-4604-828b-d2deb69270ad", false, "Dung Lê" },
                    { "aaa37047-eb43-45f1-84e0-1dd60f498b61", 0, "Đà Nẵng, Việt Nam", "4d183d0d-2a0e-47fb-af88-f8e3e18c7a83", "~image/Degree/cunhantamly.jpg", "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.", "Psychologist", "HaLe123@gamil.com", false, "12 years", false, null, "Hà Lê", null, null, null, "0912345678", null, false, 1200000m, null, "~image/Doctor/Ha_Le.png", "fd8f6d06-a59e-4bf9-8021-9cd3bdbcfaad", false, "Hà Lê" },
                    { "ae3856f6-1f0e-44d5-884f-e29a70adb447", 0, "HCM, Việt Nam", "8fa4e83c-3359-43e5-a689-0bfb8c2e3113", "~image/Degree/cunhantamly.jpg", "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.", "Psychologist", "Thang123@gamil.com", false, "10 years", false, null, "Lê Văn Thắng", null, null, null, "123456789", null, false, 1000000m, null, "~image/Doctor/Van_Thang.png", "e49e7715-5f78-47f0-82a6-1550693583c7", false, "Lê Văn Thắng" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04a83a10-81ca-4043-b1f5-5b219e333880");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28a557ab-010d-4e49-9e48-7a6bef3fd1a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d1310f1-855b-4be1-93be-e2aaaee741f3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aaa37047-eb43-45f1-84e0-1dd60f498b61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae3856f6-1f0e-44d5-884f-e29a70adb447");

            migrationBuilder.DropColumn(
                name: "CertificateUrl",
                table: "AspNetUsers");

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
    }
}
