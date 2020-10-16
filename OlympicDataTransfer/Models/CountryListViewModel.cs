using System;
using System.Collections.Generic;

namespace OlympicDataTransfer.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countries {get; set;}

        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = value;
                games.Insert(0, new Game { GameID = "all", GameName = "ALL" });
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                categories.Insert(0, new Category { CategoryID = "all", CatName = "ALL" });
            }
        }

        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";

        public string CheckActiveCat(string c) =>
            c.ToLower() == ActiveCat.ToLower() ? "active" : "";
    }
}
