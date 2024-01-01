using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class IdentificationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05ae2498-e2a9-4468-a436-ee5422838429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b8c544e-6302-4d7b-881c-e775537d5c84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d639d306-b8d7-4a16-b701-90c740736feb");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyOwnerName",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentDetails",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerIdCard",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59f596d7-94fa-48f6-8d7a-6d8d5aeb06df", null, "admin", "admin" },
                    { "5ce269db-c8a2-4816-9110-d3ea43ca88ed", null, "agent", "agent" },
                    { "df800dfd-bbdd-4c58-b8ca-154b2389429e", null, "tenant", "tenant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59f596d7-94fa-48f6-8d7a-6d8d5aeb06df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce269db-c8a2-4816-9110-d3ea43ca88ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df800dfd-bbdd-4c58-b8ca-154b2389429e");

            migrationBuilder.DropColumn(
                name: "OwnerIdCard",
                table: "PropertiesOwners");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyOwnerName",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentDetails",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PropertiesOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05ae2498-e2a9-4468-a436-ee5422838429", null, "agent", "agent" },
                    { "6b8c544e-6302-4d7b-881c-e775537d5c84", null, "admin", "admin" },
                    { "d639d306-b8d7-4a16-b701-90c740736feb", null, "tenant", "tenant" }
                });
        }
    }
}
