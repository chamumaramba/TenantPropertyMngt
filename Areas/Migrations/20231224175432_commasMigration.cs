using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class commasMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00bebb81-725f-44ea-bd25-01ee95e4f2f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4c0fc1-de52-40c0-9b98-a4522122854b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59f3fb1d-fcd9-4f59-b70d-ebd80737c91c");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Leases",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f2f837c-52ce-44c8-9494-905288f2e28e", null, "agent", "agent" },
                    { "ae5e9710-0c11-494e-a521-6befd046934e", null, "tenant", "tenant" },
                    { "ee77457f-0964-4ef4-9335-8b727fde93b1", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f2f837c-52ce-44c8-9494-905288f2e28e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5e9710-0c11-494e-a521-6befd046934e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee77457f-0964-4ef4-9335-8b727fde93b1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Leases",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00bebb81-725f-44ea-bd25-01ee95e4f2f2", null, "tenant", "tenant" },
                    { "4a4c0fc1-de52-40c0-9b98-a4522122854b", null, "agent", "agent" },
                    { "59f3fb1d-fcd9-4f59-b70d-ebd80737c91c", null, "admin", "admin" }
                });
        }
    }
}
