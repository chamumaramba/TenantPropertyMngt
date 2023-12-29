using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantPropertyMngt.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNamesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20392bea-f472-4f2b-a783-e734595d4a4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5396cb82-dbc3-4c58-9b13-5b703e8cc4f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe8a3270-a60f-4278-9291-3dc627135bd2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20392bea-f472-4f2b-a783-e734595d4a4c", null, "tenant", "tenant" },
                    { "5396cb82-dbc3-4c58-9b13-5b703e8cc4f6", null, "agent", "agent" },
                    { "fe8a3270-a60f-4278-9291-3dc627135bd2", null, "admin", "admin" }
                });
        }
    }
}
