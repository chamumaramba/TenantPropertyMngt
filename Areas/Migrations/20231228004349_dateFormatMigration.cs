using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class dateFormatMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00263e71-1824-4ac3-bdd2-e43315f28b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786bc011-9f95-4e7b-8836-59883f81af35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec5ff3f-8652-4ad9-b964-3217bf3d6e12");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "00263e71-1824-4ac3-bdd2-e43315f28b38", null, "agent", "agent" },
                    { "786bc011-9f95-4e7b-8836-59883f81af35", null, "tenant", "tenant" },
                    { "fec5ff3f-8652-4ad9-b964-3217bf3d6e12", null, "admin", "admin" }
                });
        }
    }
}
