using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class StartDateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4867efc3-b684-4efc-b871-0493097fc68a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3b66f3-055a-441f-beeb-89547a0fd903");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f29ef7fa-a1e7-48af-a43d-d9ff8f2cc375");

            migrationBuilder.DropColumn(
                name: "RentDueDate",
                table: "RentPayments");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "RentPayments",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "RentPayments");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDueDate",
                table: "RentPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4867efc3-b684-4efc-b871-0493097fc68a", null, "agent", "agent" },
                    { "7f3b66f3-055a-441f-beeb-89547a0fd903", null, "admin", "admin" },
                    { "f29ef7fa-a1e7-48af-a43d-d9ff8f2cc375", null, "tenant", "tenant" }
                });
        }
    }
}
