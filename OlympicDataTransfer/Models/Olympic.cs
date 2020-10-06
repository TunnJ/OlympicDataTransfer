using System;
using Microsoft.EntityFrameworkCore;

namespace OlympicDataTransfer.Models
{
    public class Game
    {
        public String GameID { get; set; }
        public String GameName { get; set; }
    }

    public class Category
    {
        public String CategoryID { get; set; }
        public String CatName { get; set; }
    }

    public class Country
    {
        public String CountryID { get; set; }
        public String CountryName { get; set; }
        public Game Game { get; set; }
        public Category Category { get; set; }
        public String FlagImage { get; set; }
    }

    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "win", GameName = "Winter Olympics" },
                new Game { GameID = "sum", GameName = "Summer Olympics" },
                new Game { GameID = "par", GameName = "Paralympic Games" },
                new Game { GameID = "yth", GameName = "Youth Olympic Games" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "in", CatName = "Indoor Olympics" },
                new Category { CategoryID = "out", CatName = "Outdoor Olympic Games" }
                );

            modelBuilder.Entity<Country>().HasData(
                new {CountryID = "ca", CountryName = "Canada",
                     GameID = "win", CategoryID = "in", FlagImage = "Canada.png"},
                new
                {
                    CountryID = "sw",
                    CountryName = "Sweden",
                    GameID = "win",
                    CategoryID = "in",
                    FlagImage = "Sweden.png"
                },
                new
                {
                    CountryID = "gb",
                    CountryName = "Great Britain",
                    GameID = "win",
                    CategoryID = "in",
                    FlagImage = "GreatBritain.png"
                },
                new
                {
                    CountryID = "jam",
                    CountryName = "Jamaica",
                    GameID = "win",
                    CategoryID = "out",
                    FlagImage = "Jamaica.png"
                },
                new
                {
                    CountryID = "it",
                    CountryName = "Italy",
                    GameID = "win",
                    CategoryID = "out",
                    FlagImage = "Italy.png"
                },
                new
                {
                    CountryID = "jap",
                    CountryName = "Japan",
                    GameID = "win",
                    CategoryID = "out",
                    FlagImage = "Japan.png"
                },
                new
                {
                    CountryID = "ger",
                    CountryName = "Germany",
                    GameID = "sum",
                    CategoryID = "in",
                    FlagImage = "Germany.png"
                }, new
                {
                    CountryID = "ch",
                    CountryName = "China",
                    GameID = "sum",
                    CategoryID = "in",
                    FlagImage = "China.png"
                },
                new
                {
                    CountryID = "mex",
                    CountryName = "Mexico",
                    GameID = "sum",
                    CategoryID = "in",
                    FlagImage = "Mexico.png"
                },
                new
                {
                    CountryID = "bra",
                    CountryName = "Brazil",
                    GameID = "sum",
                    CategoryID = "out",
                    FlagImage = "Brazil.png"
                },
                new
                {
                    CountryID = "net",
                    CountryName = "Netherlands",
                    GameID = "sum",
                    CategoryID = "out",
                    FlagImage = "Netherlands.png"
                }, new
                {
                    CountryID = "usa",
                    CountryName = "USA",
                    GameID = "sum",
                    CategoryID = "out",
                    FlagImage = "Usa.png"
                }, new
                {
                    CountryID = "th",
                    CountryName = "Thailand",
                    GameID = "par",
                    CategoryID = "in",
                    FlagImage = "Thailand.png"
                }, new
                {
                    CountryID = "ur",
                    CountryName = "Uruguay",
                    GameID = "par",
                    CategoryID = "in",
                    FlagImage = "Uruguay.png"
                }, new
                {
                    CountryID = "uk",
                    CountryName = "Ukraine",
                    GameID = "par",
                    CategoryID = "in",
                    FlagImage = "Ukraine.png"
                }, new
                {
                    CountryID = "au",
                    CountryName = "Austria",
                    GameID = "par",
                    CategoryID = "out",
                    FlagImage = "Austria.png"
                }, new
                {
                    CountryID = "pa",
                    CountryName = "Pakistan",
                    GameID = "par",
                    CategoryID = "out",
                    FlagImage = "Pakistan.png"
                }, new
                {
                    CountryID = "zim",
                    CountryName = "Zimbabwe",
                    GameID = "par",
                    CategoryID = "out",
                    FlagImage = "Zimbabwe.png"
                },
                new
                {
                    CountryID = "fr",
                    CountryName = "France",
                    GameID = "yth",
                    CategoryID = "in",
                    FlagImage = "France.png"
                },
                new
                {
                    CountryID = "cy",
                    CountryName = "Cyprus",
                    GameID = "yth",
                    CategoryID = "in",
                    FlagImage = "Cyprus.png"
                },
                new
                {
                    CountryID = "rus",
                    CountryName = "Russia",
                    GameID = "yth",
                    CategoryID = "in",
                    FlagImage = "Russia.png"
                },
                new
                {
                    CountryID = "fin",
                    CountryName = "Finland",
                    GameID = "yth",
                    CategoryID = "out",
                    FlagImage = "Finland.png"
                },
                new
                {
                    CountryID = "slo",
                    CountryName = "Slovakia",
                    GameID = "yth",
                    CategoryID = "out",
                    FlagImage = "Slovakia.png"
                }, new
                {
                    CountryID = "por",
                    CountryName = "Portugal",
                    GameID = "yth",
                    CategoryID = "out",
                    FlagImage = "Portugal.png"
                }
                );
        }
    }
}
