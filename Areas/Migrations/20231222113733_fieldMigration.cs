using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class fieldMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce045bd-fde7-442e-99b6-5efb7891de2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "158ef1e5-4cca-4646-894d-922400ff8a14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bebe8d1-0474-46c8-b4bc-e1a153a43225");

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14be0955-0b20-4414-8648-0a57f2817e50", null, "agent", "agent" },
                    { "2997396f-eea5-4726-961a-2717f39c409c", null, "tenant", "tenant" },
                    { "ddd13a63-bdc3-4bf4-97e8-a9b9b9a03916", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14be0955-0b20-4414-8648-0a57f2817e50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2997396f-eea5-4726-961a-2717f39c409c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd13a63-bdc3-4bf4-97e8-a9b9b9a03916");

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ce045bd-fde7-442e-99b6-5efb7891de2f", null, "admin", "admin" },
                    { "158ef1e5-4cca-4646-894d-922400ff8a14", null, "agent", "agent" },
                    { "8bebe8d1-0474-46c8-b4bc-e1a153a43225", null, "tenant", "tenant" }
                });
        }
    }
}
