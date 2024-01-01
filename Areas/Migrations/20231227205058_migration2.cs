using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "012af255-35e3-4381-8b8c-d032270b99b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bcf77dc-1f44-4b12-999e-4833722f52e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d59202e5-f132-4049-8197-5ee5ecf4eac9");

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
                    { "0bca7a3b-bada-4483-8375-50ff413173aa", null, "admin", "admin" },
                    { "91773b91-ba4d-4ecf-855c-d03ee3c569d0", null, "agent", "agent" },
                    { "d9276e1a-14fd-453b-976a-52005e0b61ac", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bca7a3b-bada-4483-8375-50ff413173aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91773b91-ba4d-4ecf-855c-d03ee3c569d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9276e1a-14fd-453b-976a-52005e0b61ac");

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
                    { "012af255-35e3-4381-8b8c-d032270b99b9", null, "tenant", "tenant" },
                    { "9bcf77dc-1f44-4b12-999e-4833722f52e5", null, "agent", "agent" },
                    { "d59202e5-f132-4049-8197-5ee5ecf4eac9", null, "admin", "admin" }
                });
        }
    }
}
