using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class propertyNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26dad55f-106f-4169-8b99-c9c2d826c3e3", null, "agent", "agent" },
                    { "46b1aa2e-a067-4823-9796-d60a2d89ca3c", null, "admin", "admin" },
                    { "af5687ea-2ee5-4e34-8f8c-33a4110e6bb4", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26dad55f-106f-4169-8b99-c9c2d826c3e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46b1aa2e-a067-4823-9796-d60a2d89ca3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af5687ea-2ee5-4e34-8f8c-33a4110e6bb4");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Leases");

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
    }
}
