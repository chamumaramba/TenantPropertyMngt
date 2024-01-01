using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class fileMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ImageFileNmae",
                table: "Properties",
                newName: "ImageFileName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20392bea-f472-4f2b-a783-e734595d4a4c", null, "tenant", "tenant" },
                    { "5396cb82-dbc3-4c58-9b13-5b703e8cc4f6", null, "agent", "agent" },
                    { "fe8a3270-a60f-4278-9291-3dc627135bd2", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20392bea-f472-4f2b-a783-e734595d4a4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5396cb82-dbc3-4c58-9b13-5b703e8cc4f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe8a3270-a60f-4278-9291-3dc627135bd2");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Properties",
                newName: "ImageFileNmae");

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
    }
}
