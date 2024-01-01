using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class RoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49e6ddc5-d2fa-4270-8d66-0061004043aa", null, "agent", "agent" },
                    { "db9219ec-3984-4b6d-bdbd-b8f511aba969", null, "tenant", "tenant" },
                    { "fdca0574-a754-49f2-905c-b690fb2b26ab", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e6ddc5-d2fa-4270-8d66-0061004043aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db9219ec-3984-4b6d-bdbd-b8f511aba969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdca0574-a754-49f2-905c-b690fb2b26ab");
        }
    }
}
