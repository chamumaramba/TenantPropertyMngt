using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class OwnerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59f596d7-94fa-48f6-8d7a-6d8d5aeb06df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce269db-c8a2-4816-9110-d3ea43ca88ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df800dfd-bbdd-4c58-b8ca-154b2389429e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "020ac922-21ba-4ebe-a0b9-3935f77b80e6", null, "tenant", "tenant" },
                    { "5bf1b4bd-a2ea-42ca-a846-618b7553a8c6", null, "agent", "agent" },
                    { "74fd0785-3428-4095-93d6-e70ff2f17912", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020ac922-21ba-4ebe-a0b9-3935f77b80e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bf1b4bd-a2ea-42ca-a846-618b7553a8c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74fd0785-3428-4095-93d6-e70ff2f17912");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59f596d7-94fa-48f6-8d7a-6d8d5aeb06df", null, "admin", "admin" },
                    { "5ce269db-c8a2-4816-9110-d3ea43ca88ed", null, "agent", "agent" },
                    { "df800dfd-bbdd-4c58-b8ca-154b2389429e", null, "tenant", "tenant" }
                });
        }
    }
}
