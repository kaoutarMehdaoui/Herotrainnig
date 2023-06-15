using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class addjointure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeroPower",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "HeroPower",
                columns: new[] { "Id", "HerosId", "PowersId" },
                values: new object[] { 5, 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeroPower",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "HeroPower",
                columns: new[] { "Id", "HerosId", "PowersId" },
                values: new object[] { 1, 2, 1 });
        }
    }
}
