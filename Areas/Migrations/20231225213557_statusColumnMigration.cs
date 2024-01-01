using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class statusColumnMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "651f167c-cba4-4afb-929c-e7196ad30d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b09104da-9140-4d59-981a-59d19445b5f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec3e7b8-c1b0-4df4-820c-ed83c3d58a83");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Leases");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Leases",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23ace692-f7a7-4715-94ab-ff7d1bf3b08e", null, "tenant", "tenant" },
                    { "4722f559-9935-461e-b802-b168defb95c6", null, "admin", "admin" },
                    { "99556acf-6d74-466e-a1de-6a84a8507d49", null, "agent", "agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23ace692-f7a7-4715-94ab-ff7d1bf3b08e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4722f559-9935-461e-b802-b168defb95c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99556acf-6d74-466e-a1de-6a84a8507d49");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Leases");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Leases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "651f167c-cba4-4afb-929c-e7196ad30d4e", null, "agent", "agent" },
                    { "b09104da-9140-4d59-981a-59d19445b5f0", null, "admin", "admin" },
                    { "eec3e7b8-c1b0-4df4-820c-ed83c3d58a83", null, "tenant", "tenant" }
                });
        }
    }
}
