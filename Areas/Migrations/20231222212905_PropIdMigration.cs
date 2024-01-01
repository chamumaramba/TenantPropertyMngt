using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class PropIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "893bfe6a-5f80-4be3-bdcc-514c141a3933");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98a7fd6d-5fb6-4629-97bd-94fdd8fd8848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1cf4ef9-52d5-42f0-8018-46a4370c7806");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Properties",
                newName: "PropertyID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,0)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 16,
                oldScale: 2);

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
                    { "217020d9-f8b8-4331-bf29-854865aa3815", null, "agent", "agent" },
                    { "27559730-2e79-48bc-8a51-dc9ecb6aa3fd", null, "tenant", "tenant" },
                    { "596e3aa2-de95-4a87-91aa-876fc512d38a", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "217020d9-f8b8-4331-bf29-854865aa3815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27559730-2e79-48bc-8a51-dc9ecb6aa3fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "596e3aa2-de95-4a87-91aa-876fc512d38a");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Properties",
                newName: "PropertyId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldPrecision: 16,
                oldScale: 2);

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
                    { "893bfe6a-5f80-4be3-bdcc-514c141a3933", null, "admin", "admin" },
                    { "98a7fd6d-5fb6-4629-97bd-94fdd8fd8848", null, "tenant", "tenant" },
                    { "e1cf4ef9-52d5-42f0-8018-46a4370c7806", null, "agent", "agent" }
                });
        }
    }
}
