using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Leases_LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tenants_TenantID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_TenantID",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932ee362-26bf-429e-ba98-c3c548a2bae9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5aa225-b7f1-479e-bb5a-480ca7be37de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf52c6f-6b85-493e-bb2b-20f4840ae366");

            migrationBuilder.DropColumn(
                name: "LeaseModelLeaseID",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyModelTenantModel",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    TenantID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyModelTenantModel", x => new { x.TenantID, x.TenantID1 });
                    table.ForeignKey(
                        name: "FK_PropertyModelTenantModel_Properties_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyModelTenantModel_Tenants_TenantID1",
                        column: x => x.TenantID1,
                        principalTable: "Tenants",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34956e50-e4f4-4c2d-be3c-34b1b9d5c30b", null, "admin", "admin" },
                    { "551ec83e-856a-418b-b8f9-1e82a1527259", null, "agent", "agent" },
                    { "8de4a84d-2982-4894-b141-a9ff525b0665", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyModelTenantModel_TenantID1",
                table: "PropertyModelTenantModel",
                column: "TenantID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropTable(
                name: "PropertyModelTenantModel");

            migrationBuilder.DropIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases");

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
                    { "932ee362-26bf-429e-ba98-c3c548a2bae9", null, "agent", "agent" },
                    { "aa5aa225-b7f1-479e-bb5a-480ca7be37de", null, "admin", "admin" },
                    { "fcf52c6f-6b85-493e-bb2b-20f4840ae366", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LeaseModelLeaseID",
                table: "Properties",
                column: "LeaseModelLeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TenantID",
                table: "Properties",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases",
                column: "PropertyID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Leases_LeaseModelLeaseID",
                table: "Properties",
                column: "LeaseModelLeaseID",
                principalTable: "Leases",
                principalColumn: "LeaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tenants_TenantID",
                table: "Properties",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID");
        }
    }
}
