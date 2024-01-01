using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class LeaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14be0955-0b20-4414-8648-0a57f2817e50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2997396f-eea5-4726-961a-2717f39c409c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd13a63-bdc3-4bf4-97e8-a9b9b9a03916");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaseModelLeaseID",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    LeaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.LeaseID);
                    table.ForeignKey(
                        name: "FK_Leases_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leases_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "031759dd-05e3-4a24-be62-8ef9a47ae391", null, "agent", "agent" },
                    { "cf3f5918-cb17-438b-bb8f-8a0c23a503e6", null, "admin", "admin" },
                    { "f6b5d079-460d-4b11-9711-3f302af24be9", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LeaseModelLeaseID",
                table: "Tenants",
                column: "LeaseModelLeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyID",
                table: "Leases",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_TenantID",
                table: "Leases",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Leases_LeaseModelLeaseID",
                table: "Tenants",
                column: "LeaseModelLeaseID",
                principalTable: "Leases",
                principalColumn: "LeaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Leases_LeaseModelLeaseID",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_LeaseModelLeaseID",
                table: "Tenants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "031759dd-05e3-4a24-be62-8ef9a47ae391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf3f5918-cb17-438b-bb8f-8a0c23a503e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b5d079-460d-4b11-9711-3f302af24be9");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LeaseModelLeaseID",
                table: "Tenants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14be0955-0b20-4414-8648-0a57f2817e50", null, "agent", "agent" },
                    { "2997396f-eea5-4726-961a-2717f39c409c", null, "tenant", "tenant" },
                    { "ddd13a63-bdc3-4bf4-97e8-a9b9b9a03916", null, "admin", "admin" }
                });
        }
    }
}
