using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class RolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b2936fc-4f44-49fa-a284-1039d3794080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30dd5070-8a61-44ab-9181-cb4efd2812eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bce9b45-40ef-4407-86bf-b28450895267");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39171e6a-5afc-48a0-9df9-5562682f6fc0", null, "admin", "admin" },
                    { "48464040-ca74-4a90-b201-5dc5d18fcac7", null, "agent", "agent" },
                    { "d16082ff-04e2-4f17-b95f-019def975e50", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39171e6a-5afc-48a0-9df9-5562682f6fc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48464040-ca74-4a90-b201-5dc5d18fcac7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d16082ff-04e2-4f17-b95f-019def975e50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b2936fc-4f44-49fa-a284-1039d3794080", null, "admin", "admin" },
                    { "30dd5070-8a61-44ab-9181-cb4efd2812eb", null, "agent", "agent" },
                    { "9bce9b45-40ef-4407-86bf-b28450895267", null, "tenant", "tenant" }
                });
        }
    }
}
