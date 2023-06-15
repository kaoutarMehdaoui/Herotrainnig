using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class SeeddataHeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Age", "Description", "FirstName", "LastName", "NameHero", "gender", "photo" },
                values: new object[,]
                {
                    { 2, 40, "Most Popular Superhero Of All Time", "Christian ", "Bale", "Batman", "male", "/Images/photoHero/Batman.jpg" },
                    { 3, 41, "He is a Marvel patriotic superhero debuting in 1941 during the World War II and ranks high among the most popular superheroes.", "Sebastian", "Tan", "CaptainAmerica", "male", "/Images/photoHero/CaptainA.jpg" },
                    { 4, 52, "Spider-Man is Marvel’s Peter Parker and the famed web slinger, also being the greatest superhero", "Tobey", "Maguire", "SpiderMan", "male", "/Images/photoHero/Spiderman.jpg" },
                    { 5, 30, "The Hulk character was created in 1962 by Jack Kirby.He is one of the most powerful Marvel characters", "Mark", "Ruffalo", "Hulk", "male", "/Images/photoHero/Hulk.png" },
                    { 6, 30, "Superman is one of the most famous and iconic superheroes of all time created by DC comics", "Dean George ", "Cain", "Superman", "male", "/Images/photoHero/Superman.jpg" },
                    { 7, 30, "Superhero Girls. has been the mainstay of DC comics for several years, being sometimes a hero and sometimes a villain.", "Halle ", "Berry", "Catwoman", "female", "/Images/photoHero/Catwoman.jpg" },
                    { 8, 35, "Female Superheroes", "Scarlett", "Johansson", "BlackWidow", "female", "/Images/photoHero/BlackWidow.jpg" },
                    { 9, 25, "Supergirl is a fictional superhero created for DC comics by Otto Binder, first appearing in The Supergirl from Krypton.", "Melissa", "Benoist", "Supergirl", "female", "/Images/photoHero/Supergirl.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Flight" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Age", "Description", "FirstName", "LastName", "NameHero", "gender", "photo" },
                values: new object[] { 1, 40, "Leading The Most Powerful Superheroes And Villains", "Christopher", "Hemsworth", "Thor", "male", "/Images/photoHero/Thor.png" });
        }
    }
}
