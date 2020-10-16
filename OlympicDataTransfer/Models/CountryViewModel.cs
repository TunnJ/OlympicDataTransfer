using System;
namespace OlympicDataTransfer.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveGame { get; set; } = "all";
        public string ActiveCat { get; set; } = "all";
    }
}
