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
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveCat(activeCat);

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

        public ViewResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Category)
                .FirstOrDefault(c => c.CountryID == id),
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Category)
                .Where(c => c.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            return RedirectToAction("Index",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveCat = session.GetActiveCat()
                });

        }
    }
}
