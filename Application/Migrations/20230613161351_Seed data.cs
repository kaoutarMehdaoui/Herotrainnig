using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Age", "Description", "FirstName", "LastName", "NameHero", "gender", "photo" },
                values: new object[] { 1, 40, "Leading The Most Powerful Superheroes And Villains", "Christopher", "Hemsworth", "Thor", "male", "/Images/photoHero/Thor.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
