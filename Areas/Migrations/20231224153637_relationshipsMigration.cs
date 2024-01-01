using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModelTenantModel_Properties_TenantID",
                table: "PropertyModelTenantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantsTenantID",
                table: "PropertyModelTenantModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyModelTenantModel",
                table: "PropertyModelTenantModel");

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

            migrationBuilder.RenameTable(
                name: "PropertyModelTenantModel",
                newName: "TenantProperty");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyModelTenantModel_TenantsTenantID",
                table: "TenantProperty",
                newName: "IX_TenantProperty_TenantsTenantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty",
                columns: new[] { "TenantID", "TenantsTenantID" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e535000-fe87-49e8-ae09-63636727b1d1", null, "admin", "admin" },
                    { "88e5b864-0d4f-42c6-9b61-5c959b92a19b", null, "tenant", "tenant" },
                    { "e22bdd20-23d3-405b-8d45-d35ba0c70c2d", null, "agent", "agent" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperty_Properties_TenantID",
                table: "TenantProperty",
                column: "TenantID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperty_Tenants_TenantsTenantID",
                table: "TenantProperty",
                column: "TenantsTenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperty_Properties_TenantID",
                table: "TenantProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperty_Tenants_TenantsTenantID",
                table: "TenantProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e535000-fe87-49e8-ae09-63636727b1d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88e5b864-0d4f-42c6-9b61-5c959b92a19b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22bdd20-23d3-405b-8d45-d35ba0c70c2d");

            migrationBuilder.RenameTable(
                name: "TenantProperty",
                newName: "PropertyModelTenantModel");

            migrationBuilder.RenameIndex(
                name: "IX_TenantProperty_TenantsTenantID",
                table: "PropertyModelTenantModel",
                newName: "IX_PropertyModelTenantModel_TenantsTenantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyModelTenantModel",
                table: "PropertyModelTenantModel",
                columns: new[] { "TenantID", "TenantsTenantID" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26dad55f-106f-4169-8b99-c9c2d826c3e3", null, "agent", "agent" },
                    { "46b1aa2e-a067-4823-9796-d60a2d89ca3c", null, "admin", "admin" },
                    { "af5687ea-2ee5-4e34-8f8c-33a4110e6bb4", null, "tenant", "tenant" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModelTenantModel_Properties_TenantID",
                table: "PropertyModelTenantModel",
                column: "TenantID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantsTenantID",
                table: "PropertyModelTenantModel",
                column: "TenantsTenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
