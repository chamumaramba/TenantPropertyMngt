using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class rentChangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa905ab5-75b5-46d7-90da-121be9fbc7f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5815c61-8345-4526-ac92-25a6625054c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb0a7069-d328-4c92-93a6-8e004057d07c");

            migrationBuilder.RenameColumn(
                name: "PaymentAmount",
                table: "RentPayments",
                newName: "Rent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29555196-8225-46aa-bdc1-a5b08be27fee", null, "agent", "agent" },
                    { "520b6f53-cdae-4a62-9b55-a31c57edc43f", null, "tenant", "tenant" },
                    { "b370719f-96bd-4773-9bc4-7d6c24c20dc6", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29555196-8225-46aa-bdc1-a5b08be27fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "520b6f53-cdae-4a62-9b55-a31c57edc43f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b370719f-96bd-4773-9bc4-7d6c24c20dc6");

            migrationBuilder.RenameColumn(
                name: "Rent",
                table: "RentPayments",
                newName: "PaymentAmount");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa905ab5-75b5-46d7-90da-121be9fbc7f4", null, "agent", "agent" },
                    { "e5815c61-8345-4526-ac92-25a6625054c4", null, "admin", "admin" },
                    { "eb0a7069-d328-4c92-93a6-8e004057d07c", null, "tenant", "tenant" }
                });
        }
    }
}
