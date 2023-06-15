using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class addjointure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeroPower",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "HeroPower",
                columns: new[] { "Id", "HerosId", "PowersId" },
                values: new object[] { 6, 1, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeroPower",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "HeroPower",
                columns: new[] { "Id", "HerosId", "PowersId" },
                values: new object[] { 5, 2, 1 });
        }
    }
}
