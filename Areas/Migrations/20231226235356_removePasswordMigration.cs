using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class removePasswordMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39727130-2729-4d17-89ea-377908a61eed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac856413-8b07-4fce-a6f1-672ac44aa53c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6e10f7c-76e9-48b3-81a9-9d64716a05ab");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tenants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ffd8c36-dadd-4278-8ac3-b9ce91063e20", null, "admin", "admin" },
                    { "89d8908d-8918-459c-81f0-4d302026c271", null, "tenant", "tenant" },
                    { "9697842e-e7b1-42fe-b53e-5faf4fdd017e", null, "agent", "agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ffd8c36-dadd-4278-8ac3-b9ce91063e20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d8908d-8918-459c-81f0-4d302026c271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9697842e-e7b1-42fe-b53e-5faf4fdd017e");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39727130-2729-4d17-89ea-377908a61eed", null, "tenant", "tenant" },
                    { "ac856413-8b07-4fce-a6f1-672ac44aa53c", null, "admin", "admin" },
                    { "d6e10f7c-76e9-48b3-81a9-9d64716a05ab", null, "agent", "agent" }
                });
        }
    }
}
