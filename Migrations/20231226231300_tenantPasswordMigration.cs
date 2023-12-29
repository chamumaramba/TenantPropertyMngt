using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class tenantPasswordMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39171e6a-5afc-48a0-9df9-5562682f6fc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48464040-ca74-4a90-b201-5dc5d18fcac7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d16082ff-04e2-4f17-b95f-019def975e50");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "39171e6a-5afc-48a0-9df9-5562682f6fc0", null, "admin", "admin" },
                    { "48464040-ca74-4a90-b201-5dc5d18fcac7", null, "agent", "agent" },
                    { "d16082ff-04e2-4f17-b95f-019def975e50", null, "tenant", "tenant" }
                });
        }
    }
}
