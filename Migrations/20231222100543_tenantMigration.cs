using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class tenantMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6347c04-6606-42d7-96ea-1744409c951b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d61163a9-d2ee-4f55-96e2-f7a1d854cc62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa5c5133-0a35-4e89-909c-6f1542bb7f48");

            migrationBuilder.AddColumn<int>(
                name: "TenantID",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ce045bd-fde7-442e-99b6-5efb7891de2f", null, "admin", "admin" },
                    { "158ef1e5-4cca-4646-894d-922400ff8a14", null, "agent", "agent" },
                    { "8bebe8d1-0474-46c8-b4bc-e1a153a43225", null, "tenant", "tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TenantID",
                table: "Properties",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Tenants_TenantID",
                table: "Properties",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Tenants_TenantID",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Properties_TenantID",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce045bd-fde7-442e-99b6-5efb7891de2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "158ef1e5-4cca-4646-894d-922400ff8a14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bebe8d1-0474-46c8-b4bc-e1a153a43225");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Properties");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6347c04-6606-42d7-96ea-1744409c951b", null, "tenant", "tenant" },
                    { "d61163a9-d2ee-4f55-96e2-f7a1d854cc62", null, "agent", "agent" },
                    { "fa5c5133-0a35-4e89-909c-6f1542bb7f48", null, "admin", "admin" }
                });
        }
    }
}
