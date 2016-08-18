using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Services
{
    public abstract class WeatherServiceBase : IWeatherService
    {
        //Deletle this metod... ????
        //public abstract IEnumerable<Geoname> GetGeonames(string startsWith, string country, int maxRows);
        
        public abstract IEnumerable<Forecast> RefreshForecast(string lat, string lon);
    }
}
