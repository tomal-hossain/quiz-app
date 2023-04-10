using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateAdminUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a49e3ac-aa54-4b4c-8e7a-b9f99f67e7f7", "1f900332-556d-4f74-8700-91161c4118b4", "Admin", "ADMIN" },
                    { "e5eb009a-767d-4b5e-b3cd-3513063e46c6", "380bdb8e-6f39-444f-830e-903a0f3b4482", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "662278bb-5893-4b8c-89f0-592edfacef22", 0, "5b2f5a62-691c-4188-99f3-068c158d8677", "admin@gmail.com", true, false, null, "Admin User", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJ/t6u7aASZG6DMGaFkLr5XlRW3NRRHWbMpZwWG2FzfLR1k+YwiOgiKuuS+UQEtv+w==", null, false, "0197e84b-fd4e-4622-956b-870fe6102150", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8a49e3ac-aa54-4b4c-8e7a-b9f99f67e7f7", "662278bb-5893-4b8c-89f0-592edfacef22" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5eb009a-767d-4b5e-b3cd-3513063e46c6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8a49e3ac-aa54-4b4c-8e7a-b9f99f67e7f7", "662278bb-5893-4b8c-89f0-592edfacef22" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a49e3ac-aa54-4b4c-8e7a-b9f99f67e7f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "662278bb-5893-4b8c-89f0-592edfacef22");
        }
    }
}
