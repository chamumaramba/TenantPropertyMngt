using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class IDChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32e8afd2-9732-46ab-b64e-cfbe28078032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f317fa0-43b5-46ff-afed-0c85f8895824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2e9238f-fbfb-493a-8953-f7301036377b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "296be9c6-183d-4c98-affe-8784a011a2eb", null, "admin", "admin" },
                    { "5ec73935-b53c-4645-864b-cd0738ec5004", null, "agent", "agent" },
                    { "ccf7ebe0-e98b-4d93-a3fb-08c568878c59", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "296be9c6-183d-4c98-affe-8784a011a2eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ec73935-b53c-4645-864b-cd0738ec5004");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccf7ebe0-e98b-4d93-a3fb-08c568878c59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32e8afd2-9732-46ab-b64e-cfbe28078032", null, "agent", "agent" },
                    { "8f317fa0-43b5-46ff-afed-0c85f8895824", null, "admin", "admin" },
                    { "d2e9238f-fbfb-493a-8953-f7301036377b", null, "tenant", "tenant" }
                });
        }
    }
}
