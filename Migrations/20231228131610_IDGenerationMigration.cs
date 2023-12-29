using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class IDGenerationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824260bd-5480-49e4-b19f-1b82a09177ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0ed23b-8b56-4810-826f-f89e6661298e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb332040-05f8-4d8f-9300-9a67bc680526");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "824260bd-5480-49e4-b19f-1b82a09177ed", null, "agent", "agent" },
                    { "be0ed23b-8b56-4810-826f-f89e6661298e", null, "admin", "admin" },
                    { "eb332040-05f8-4d8f-9300-9a67bc680526", null, "tenant", "tenant" }
                });
        }
    }
}
