using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class DateDefaultMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2268b66f-60d7-4ea7-b8d8-8a20a0d1ddd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ce94ab7-b59f-4af8-ae93-df579faea7fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c92f771c-b9c6-4238-8942-5164fd2faeeb");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "RentPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01802a70-41ff-4059-be34-2dfa80d1c815", null, "agent", "agent" },
                    { "1be2bcbb-a7b7-469b-84e3-82be4a7773d6", null, "admin", "admin" },
                    { "42fd150f-a8b6-43cc-8291-44b9e172e83c", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01802a70-41ff-4059-be34-2dfa80d1c815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1be2bcbb-a7b7-469b-84e3-82be4a7773d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42fd150f-a8b6-43cc-8291-44b9e172e83c");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "RentPayments",
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
                    { "2268b66f-60d7-4ea7-b8d8-8a20a0d1ddd6", null, "admin", "admin" },
                    { "9ce94ab7-b59f-4af8-ae93-df579faea7fd", null, "tenant", "tenant" },
                    { "c92f771c-b9c6-4238-8942-5164fd2faeeb", null, "agent", "agent" }
                });
        }
    }
}
