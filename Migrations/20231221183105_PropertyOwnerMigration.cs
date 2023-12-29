using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class PropertyOwnerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2be42e94-485e-436f-a704-0e1d53d2e582");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3424ac43-ea44-43da-b45a-2c393633c711");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9990c2b1-971c-4ef6-b303-8890d6619954");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyDescription",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFileName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyOwnerID",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropertiesOwners",
                columns: table => new
                {
                    PropertyOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesOwners", x => x.PropertyOwnerID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6347c04-6606-42d7-96ea-1744409c951b", null, "tenant", "tenant" },
                    { "d61163a9-d2ee-4f55-96e2-f7a1d854cc62", null, "agent", "agent" },
                    { "fa5c5133-0a35-4e89-909c-6f1542bb7f48", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyOwnerID",
                table: "Properties",
                column: "PropertyOwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertiesOwners_PropertyOwnerID",
                table: "Properties",
                column: "PropertyOwnerID",
                principalTable: "PropertiesOwners",
                principalColumn: "PropertyOwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertiesOwners_PropertyOwnerID",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropertiesOwners");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyOwnerID",
                table: "Properties");

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

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyOwnerID",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyDescription",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageFileName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2be42e94-485e-436f-a704-0e1d53d2e582", null, "admin", "admin" },
                    { "3424ac43-ea44-43da-b45a-2c393633c711", null, "agent", "agent" },
                    { "9990c2b1-971c-4ef6-b303-8890d6619954", null, "tenant", "tenant" }
                });
        }
    }
}
