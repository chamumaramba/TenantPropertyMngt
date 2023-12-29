using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class PropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d94c919-a8e8-4857-9d17-5179d5d67ccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ee7491-0308-4c7e-95cb-e95584a5f93a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e97e0d14-3f8c-497d-8e2c-57c2ad5d77b9");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Properties",
                newName: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Properties",
                newName: "PropertyName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Properties",
                newName: "PropertyDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95df42cb-f488-42a2-8744-1708f58798bd", null, "agent", "agent" },
                    { "adcb94fd-17cd-46a7-85ed-f0fc254651d2", null, "tenant", "tenant" },
                    { "cbc05141-7db8-4a70-a344-b1157354dc05", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95df42cb-f488-42a2-8744-1708f58798bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adcb94fd-17cd-46a7-85ed-f0fc254651d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc05141-7db8-4a70-a344-b1157354dc05");

            migrationBuilder.RenameColumn(
                name: "PropertyType",
                table: "Properties",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "PropertyName",
                table: "Properties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PropertyDescription",
                table: "Properties",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d94c919-a8e8-4857-9d17-5179d5d67ccd", null, "admin", "admin" },
                    { "e0ee7491-0308-4c7e-95cb-e95584a5f93a", null, "tenant", "tenant" },
                    { "e97e0d14-3f8c-497d-8e2c-57c2ad5d77b9", null, "agent", "agent" }
                });
        }
    }
}
