using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class decimal2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "278e5ce0-2151-441a-814e-e90da6e735a1", null, "admin", "admin" },
                    { "2d849d04-3817-4e32-b102-14210860af90", null, "tenant", "tenant" },
                    { "b0988477-50a1-46ee-a9b1-c26d07a27cc2", null, "agent", "agent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "278e5ce0-2151-441a-814e-e90da6e735a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d849d04-3817-4e32-b102-14210860af90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0988477-50a1-46ee-a9b1-c26d07a27cc2");

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
    }
}
