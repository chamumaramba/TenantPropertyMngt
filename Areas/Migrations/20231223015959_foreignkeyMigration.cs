using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenantName",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Leases",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Leases",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "932ee362-26bf-429e-ba98-c3c548a2bae9", null, "agent", "agent" },
                    { "aa5aa225-b7f1-479e-bb5a-480ca7be37de", null, "admin", "admin" },
                    { "fcf52c6f-6b85-493e-bb2b-20f4840ae366", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases",
                column: "PropertyID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932ee362-26bf-429e-ba98-c3c548a2bae9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5aa225-b7f1-479e-bb5a-480ca7be37de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf52c6f-6b85-493e-bb2b-20f4840ae366");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "decimal(18,0)",
                precision: 16,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenantName",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Leases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Leases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
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

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Properties_PropertyID",
                table: "Leases",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
