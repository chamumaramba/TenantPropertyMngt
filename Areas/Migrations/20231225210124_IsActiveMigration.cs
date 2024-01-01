using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "534051e1-d9c7-44cd-aac8-f08f876e0029");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf6536e0-3649-4005-83d2-d406419c58c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e873d9-a116-44e5-9261-2cd022f4c287");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Leases");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Leases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "651f167c-cba4-4afb-929c-e7196ad30d4e", null, "agent", "agent" },
                    { "b09104da-9140-4d59-981a-59d19445b5f0", null, "admin", "admin" },
                    { "eec3e7b8-c1b0-4df4-820c-ed83c3d58a83", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "651f167c-cba4-4afb-929c-e7196ad30d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b09104da-9140-4d59-981a-59d19445b5f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec3e7b8-c1b0-4df4-820c-ed83c3d58a83");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Leases");

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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "534051e1-d9c7-44cd-aac8-f08f876e0029", null, "admin", "admin" },
                    { "bf6536e0-3649-4005-83d2-d406419c58c0", null, "agent", "agent" },
                    { "d1e873d9-a116-44e5-9261-2cd022f4c287", null, "tenant", "tenant" }
                });
        }
    }
}
