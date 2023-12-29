using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class spellingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209336d5-3847-48e8-b4d5-7d7d38ac9817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "776c4ce6-d28a-4b09-81af-295287ec4aff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "802b9e1e-9189-48aa-bffa-6c58a78915f3");

            migrationBuilder.RenameColumn(
                name: "Duedate",
                table: "RentPayments",
                newName: "DueDate");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "RentPayments",
                newName: "Duedate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "209336d5-3847-48e8-b4d5-7d7d38ac9817", null, "agent", "agent" },
                    { "776c4ce6-d28a-4b09-81af-295287ec4aff", null, "admin", "admin" },
                    { "802b9e1e-9189-48aa-bffa-6c58a78915f3", null, "tenant", "tenant" }
                });
        }
    }
}
