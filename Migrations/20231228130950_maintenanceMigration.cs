using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class maintenanceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    MaintenanceIssueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateReported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantModelTenantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.MaintenanceIssueID);
                    table.ForeignKey(
                        name: "FK_Maintenances_Tenants_TenantModelTenantID",
                        column: x => x.TenantModelTenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "824260bd-5480-49e4-b19f-1b82a09177ed", null, "agent", "agent" },
                    { "be0ed23b-8b56-4810-826f-f89e6661298e", null, "admin", "admin" },
                    { "eb332040-05f8-4d8f-9300-9a67bc680526", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_TenantModelTenantID",
                table: "Maintenances",
                column: "TenantModelTenantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824260bd-5480-49e4-b19f-1b82a09177ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0ed23b-8b56-4810-826f-f89e6661298e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb332040-05f8-4d8f-9300-9a67bc680526");

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
    }
}
