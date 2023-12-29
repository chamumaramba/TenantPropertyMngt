using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class RentPaymentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ffd8c36-dadd-4278-8ac3-b9ce91063e20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89d8908d-8918-459c-81f0-4d302026c271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9697842e-e7b1-42fe-b53e-5faf4fdd017e");

            migrationBuilder.CreateTable(
                name: "RentPayments",
                columns: table => new
                {
                    RentPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseID = table.Column<int>(type: "int", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPayments", x => x.RentPaymentID);
                    table.ForeignKey(
                        name: "FK_RentPayments_Leases_LeaseID",
                        column: x => x.LeaseID,
                        principalTable: "Leases",
                        principalColumn: "LeaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa905ab5-75b5-46d7-90da-121be9fbc7f4", null, "agent", "agent" },
                    { "e5815c61-8345-4526-ac92-25a6625054c4", null, "admin", "admin" },
                    { "eb0a7069-d328-4c92-93a6-8e004057d07c", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentPayments_LeaseID",
                table: "RentPayments",
                column: "LeaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentPayments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa905ab5-75b5-46d7-90da-121be9fbc7f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5815c61-8345-4526-ac92-25a6625054c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb0a7069-d328-4c92-93a6-8e004057d07c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ffd8c36-dadd-4278-8ac3-b9ce91063e20", null, "admin", "admin" },
                    { "89d8908d-8918-459c-81f0-4d302026c271", null, "tenant", "tenant" },
                    { "9697842e-e7b1-42fe-b53e-5faf4fdd017e", null, "agent", "agent" }
                });
        }
    }
}
