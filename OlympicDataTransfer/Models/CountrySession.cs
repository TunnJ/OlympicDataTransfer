using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace OlympicDataTransfer.Models
{
    public class CountrySession
    {
        private const string CountrysKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string CatKey = "cat";

        private ISession session { get; set; }
        public CountrySession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> teams)
        {
            session.SetObject(CountrysKey, teams);
            session.SetInt32(CountKey, teams.Count);
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountrysKey) ?? new List<Country>();

        public int GetMyCountryCount() => session.GetInt32(CountKey) ?? 0;

        public void SetActiveGame(string activeGame) => session.SetString(GameKey, activeGame);
        public string GetActiveGame() => session.GetString(GameKey);

        public void SetActiveCat(string activeCat) => session.SetString(CatKey, activeCat);
        public string GetActiveCat() => session.GetString(CatKey);

        public void RemoveMyTeams()
        {
            session.Remove(CountrysKey);
            session.Remove(CountKey);
        }

    }
}
