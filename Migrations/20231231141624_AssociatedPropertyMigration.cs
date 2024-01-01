using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class AssociatedPropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperty_Tenants_TenantsTenantID",
                table: "TenantProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty");

            migrationBuilder.DropIndex(
                name: "IX_TenantProperty_TenantsTenantID",
                table: "TenantProperty");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01802a70-41ff-4059-be34-2dfa80d1c815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1be2bcbb-a7b7-469b-84e3-82be4a7773d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42fd150f-a8b6-43cc-8291-44b9e172e83c");

            migrationBuilder.RenameColumn(
                name: "TenantsTenantID",
                table: "TenantProperty",
                newName: "PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty",
                columns: new[] { "PropertyID", "TenantID" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "017fbe85-a6a2-44af-b942-bb5e2d48a981", null, "agent", "agent" },
                    { "4b8cd82b-d763-4bef-9eb0-ceab59f1a5e1", null, "tenant", "tenant" },
                    { "98c7a1ab-d38a-425a-af2f-3e9127f535c2", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperty_TenantID",
                table: "TenantProperty",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperty_Tenants_PropertyID",
                table: "TenantProperty",
                column: "PropertyID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantProperty_Tenants_PropertyID",
                table: "TenantProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty");

            migrationBuilder.DropIndex(
                name: "IX_TenantProperty_TenantID",
                table: "TenantProperty");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017fbe85-a6a2-44af-b942-bb5e2d48a981");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8cd82b-d763-4bef-9eb0-ceab59f1a5e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98c7a1ab-d38a-425a-af2f-3e9127f535c2");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "TenantProperty",
                newName: "TenantsTenantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantProperty",
                table: "TenantProperty",
                columns: new[] { "TenantID", "TenantsTenantID" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01802a70-41ff-4059-be34-2dfa80d1c815", null, "agent", "agent" },
                    { "1be2bcbb-a7b7-469b-84e3-82be4a7773d6", null, "admin", "admin" },
                    { "42fd150f-a8b6-43cc-8291-44b9e172e83c", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperty_TenantsTenantID",
                table: "TenantProperty",
                column: "TenantsTenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantProperty_Tenants_TenantsTenantID",
                table: "TenantProperty",
                column: "TenantsTenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
