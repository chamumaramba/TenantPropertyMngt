using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class rentStatusMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "494f478c-31f6-46fc-9e39-6ca09ac4f5d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86f547a1-0346-4d6d-a72e-77e29d9d3e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3aa3937-96c7-4e16-acd2-152fc50bdee4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00263e71-1824-4ac3-bdd2-e43315f28b38", null, "agent", "agent" },
                    { "786bc011-9f95-4e7b-8836-59883f81af35", null, "tenant", "tenant" },
                    { "fec5ff3f-8652-4ad9-b964-3217bf3d6e12", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00263e71-1824-4ac3-bdd2-e43315f28b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786bc011-9f95-4e7b-8836-59883f81af35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec5ff3f-8652-4ad9-b964-3217bf3d6e12");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "494f478c-31f6-46fc-9e39-6ca09ac4f5d7", null, "admin", "admin" },
                    { "86f547a1-0346-4d6d-a72e-77e29d9d3e03", null, "agent", "agent" },
                    { "d3aa3937-96c7-4e16-acd2-152fc50bdee4", null, "tenant", "tenant" }
                });
        }
    }
}
