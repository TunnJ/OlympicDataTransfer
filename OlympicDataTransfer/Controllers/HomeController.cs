using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlympicDataTransfer.Models;

namespace OlympicDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }
        public ViewResult Index(string activeGame = "all", string activeCat = "all")
        {
            var model = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveCat = activeCat,
                Games = context.Games.ToList(),
                Categories = context.Categories.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if(activeGame != "all")
            {
                query = query.Where(
                    c => c.Game.GameID.ToLower() == activeGame.ToLower()
                    );
            }

            if(activeCat != "all")
            {
                query = query.Where(
                    c => c.Category.CategoryID.ToLower() == activeCat.ToLower()
                    );
            }

            ViewBag.gameRoute = activeGame;
            ViewBag.catRoute = activeCat;
            query = query.OrderBy(country => country.CountryName);
            model.Countries = query.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
