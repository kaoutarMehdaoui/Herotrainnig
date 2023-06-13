using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Powers> Powers { get; set; }
        public DbSet<Heros> Heros { get; set; }
        public DbSet<HeroPower> HeroPower { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        //fill data in the DataBase 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 1,

                Name = "Flight",


            }
                );

            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 2,

                Name = "Invisibility",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 3,

                Name = "Shapeshifting",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 4,

                Name = "Healing",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 5,

                Name = "Super Speed",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 6,

                Name = "Super Strength",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 7,

                Name = "Under Water Control",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 8,

                Name = "Telekinesis ",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 9,

                Name = "Elemental Control",

            }
              );
            modelBuilder.Entity<Powers>().HasData(new Powers
            {
                Id = 10,

                Name = "Mind Control",

            }
              );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 1,
                FirstName = "Christopher",
                LastName = "Hemsworth",
                Age = 40,
                NameHero = "Thor",
                Description = "Leading The Most Powerful Superheroes And Villains",
                gender = "male",
                photo = "/Images/photoHero/Thor.png",



            }
             );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 2,
                FirstName = "Christian ",
                LastName = "Bale",
                Age = 40,
                NameHero = "Batman",
                Description = "Most Popular Superhero Of All Time",
                gender = "male",
                photo = "/Images/photoHero/Batman.jpg",
            }
            );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 3,
                FirstName = "Sebastian",
                LastName = "Tan",
                Age = 41,
                NameHero = "CaptainAmerica",
                Description = "He is a Marvel patriotic superhero debuting in 1941 during the World War II and ranks high among the most popular superheroes.",
                gender = "male",
                photo = "/Images/photoHero/CaptainA.jpg",
            }
           ); ;
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 4,
                FirstName = "Tobey",
                LastName = "Maguire",
                Age = 52,
                NameHero = "SpiderMan",
                Description = "Spider-Man is Marvel’s Peter Parker and the famed web slinger, also being the greatest superhero",
                gender = "male",
                photo = "/Images/photoHero/Spiderman.jpg",
            }
         );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 5,
                FirstName = "Mark",
                LastName = "Ruffalo",
                Age = 30,
                NameHero = "Hulk",
                Description = "The Hulk character was created in 1962 by Jack Kirby.He is one of the most powerful Marvel characters",
                gender = "male",
                photo = "/Images/photoHero/Hulk.png",
            }
         );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 6,
                FirstName = "Dean George ",
                LastName = "Cain",
                Age = 30,
                NameHero = "Superman",
                Description = "Superman is one of the most famous and iconic superheroes of all time created by DC comics",
                gender = "male",
                photo = "/Images/photoHero/Superman.jpg",
            }
         );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 7,
                FirstName = "Halle ",
                LastName = "Berry",
                Age = 30,
                NameHero = "Catwoman",
                Description = "Superhero Girls. has been the mainstay of DC comics for several years, being sometimes a hero and sometimes a villain.",
                gender = "female",
                photo = "/Images/photoHero/Catwoman.jpg",
            }
        );
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 8,
                FirstName = "Scarlett",
                LastName = "Johansson",
                Age = 35,
                NameHero = "BlackWidow",
                Description = "Female Superheroes",
                gender = "female",
                photo = "/Images/photoHero/BlackWidow.jpg",
            }
);
            modelBuilder.Entity<Heros>().HasData(new Heros
            {
                Id = 9,
                FirstName = "Melissa",
                LastName = "Benoist",
                Age = 25,
                NameHero = "Supergirl",
                Description = "Supergirl is a fictional superhero created for DC comics by Otto Binder, first appearing in The Supergirl from Krypton.",
                gender = "female",
                photo = "/Images/photoHero/Supergirl.jpg",
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 1,
                PowersId = 2,
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 1,
                PowersId = 3,
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 1,
                PowersId = 3,
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 9,
                PowersId = 3,
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 9,
                PowersId = 5,
            }
);
            modelBuilder.Entity<Heros>().HasData(new HeroPower
            {
                HerosId = 9,
                PowersId = 6,
            }
);
        }
    }
}
