using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class LeaseTenantMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "031759dd-05e3-4a24-be62-8ef9a47ae391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf3f5918-cb17-438b-bb8f-8a0c23a503e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b5d079-460d-4b11-9711-3f302af24be9");

            migrationBuilder.AddColumn<int>(
                name: "LeaseModelLeaseID",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20e8d4f4-7694-499e-a159-7a68035d0928", null, "tenant", "tenant" },
                    { "f1a603ce-11a8-4c90-bb5c-4c3c7aeeb031", null, "admin", "admin" },
                    { "f354ceec-f45a-45c8-9674-85fff3dcdbf6", null, "agent", "agent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LeaseModelLeaseID",
                table: "Properties",
                column: "LeaseModelLeaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Leases_LeaseModelLeaseID",
                table: "Properties",
                column: "LeaseModelLeaseID",
                principalTable: "Leases",
                principalColumn: "LeaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Leases_LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20e8d4f4-7694-499e-a159-7a68035d0928");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1a603ce-11a8-4c90-bb5c-4c3c7aeeb031");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f354ceec-f45a-45c8-9674-85fff3dcdbf6");

            migrationBuilder.DropColumn(
                name: "LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "031759dd-05e3-4a24-be62-8ef9a47ae391", null, "agent", "agent" },
                    { "cf3f5918-cb17-438b-bb8f-8a0c23a503e6", null, "admin", "admin" },
                    { "f6b5d079-460d-4b11-9711-3f302af24be9", null, "tenant", "tenant" }
                });
        }
    }
}
