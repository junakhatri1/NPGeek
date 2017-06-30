using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public string TempScale { get; set; }

        public List<Weather> fiveDaysWeather { get; set; }

        public int ChangeToCelsius(int temperature)
        {
            double degrees = (((temperature - 32) * 5) / 9);
            return Convert.ToInt32(degrees);

        }

        public string RecommendationForecast(string forecast)
        {
            if(forecast == "snow")
            {
                return "Pack your snowshoes!";
            }
            else if(forecast == "rain")
            {
                return "Pack your rain gear and wear waterproof shoes!";
            }
            else if(forecast == "thunderstorms")
            {
                return "Seek shelter and avoid hiking on exposed ridges!";
            }
            else if(forecast == "sunny")
            {
                return "Pack your sunblock!";
            }
            else
            {
                return "";
            }
            
        }

        public string RecommendationTemp(int high, int low)
        {
            if ((high - low > 20) && (high > 75))
            {
                return "Bring an extra gallon of water and wear breatheable layers!";
            }
            else if((high - low > 20) && (low < 20))
            {
                return "Beware of frigid temperatures and wear breatheable layers!";
            }
            else if(high - low > 20)
            {
                return "Wear breatheable layers!";
            }
            else if((high > 75))
            {
                return "Bring an extra gallon of water!";
            }
            else if (low < 20)
            {
                return "Beware of frigid temperatures!";
            }
            else
            {
                return "";
            }
        }
    }
}