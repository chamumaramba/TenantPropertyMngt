using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class revertDateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4592cdcb-c29e-43fc-a6f7-257776a6ad50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac7a1af-18fc-42f8-a4eb-ab8605b94351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e6ff804-9fde-4107-838f-25c6df2be7a6");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "RentPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07953808-8d63-4df3-ac1a-9fba63ede637", null, "admin", "admin" },
                    { "1d074468-ab62-4f2d-a9f8-f6e7e4366c27", null, "agent", "agent" },
                    { "67623dbb-f1c7-47c2-b8ce-60192f9bce53", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07953808-8d63-4df3-ac1a-9fba63ede637");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d074468-ab62-4f2d-a9f8-f6e7e4366c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67623dbb-f1c7-47c2-b8ce-60192f9bce53");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RentPayments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4592cdcb-c29e-43fc-a6f7-257776a6ad50", null, "agent", "agent" },
                    { "5ac7a1af-18fc-42f8-a4eb-ab8605b94351", null, "admin", "admin" },
                    { "9e6ff804-9fde-4107-838f-25c6df2be7a6", null, "tenant", "tenant" }
                });
        }
    }
}
