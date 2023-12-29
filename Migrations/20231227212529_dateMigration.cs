using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class dateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "RentPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Duedate",
                table: "RentPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "209336d5-3847-48e8-b4d5-7d7d38ac9817", null, "agent", "agent" },
                    { "776c4ce6-d28a-4b09-81af-295287ec4aff", null, "admin", "admin" },
                    { "802b9e1e-9189-48aa-bffa-6c58a78915f3", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209336d5-3847-48e8-b4d5-7d7d38ac9817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "776c4ce6-d28a-4b09-81af-295287ec4aff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "802b9e1e-9189-48aa-bffa-6c58a78915f3");

            migrationBuilder.DropColumn(
                name: "Duedate",
                table: "RentPayments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RentPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
