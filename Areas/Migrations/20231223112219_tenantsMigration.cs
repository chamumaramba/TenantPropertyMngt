using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class tenantsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantID1",
                table: "PropertyModelTenantModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34956e50-e4f4-4c2d-be3c-34b1b9d5c30b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "551ec83e-856a-418b-b8f9-1e82a1527259");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8de4a84d-2982-4894-b141-a9ff525b0665");

            migrationBuilder.RenameColumn(
                name: "TenantID1",
                table: "PropertyModelTenantModel",
                newName: "TenantsTenantID");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyModelTenantModel_TenantID1",
                table: "PropertyModelTenantModel",
                newName: "IX_PropertyModelTenantModel_TenantsTenantID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05ae2498-e2a9-4468-a436-ee5422838429", null, "agent", "agent" },
                    { "6b8c544e-6302-4d7b-881c-e775537d5c84", null, "admin", "admin" },
                    { "d639d306-b8d7-4a16-b701-90c740736feb", null, "tenant", "tenant" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantsTenantID",
                table: "PropertyModelTenantModel",
                column: "TenantsTenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantsTenantID",
                table: "PropertyModelTenantModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05ae2498-e2a9-4468-a436-ee5422838429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b8c544e-6302-4d7b-881c-e775537d5c84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d639d306-b8d7-4a16-b701-90c740736feb");

            migrationBuilder.RenameColumn(
                name: "TenantsTenantID",
                table: "PropertyModelTenantModel",
                newName: "TenantID1");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyModelTenantModel_TenantsTenantID",
                table: "PropertyModelTenantModel",
                newName: "IX_PropertyModelTenantModel_TenantID1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34956e50-e4f4-4c2d-be3c-34b1b9d5c30b", null, "admin", "admin" },
                    { "551ec83e-856a-418b-b8f9-1e82a1527259", null, "agent", "agent" },
                    { "8de4a84d-2982-4894-b141-a9ff525b0665", null, "tenant", "tenant" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyModelTenantModel_Tenants_TenantID1",
                table: "PropertyModelTenantModel",
                column: "TenantID1",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
