using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Services
{
    public interface IWeatherService
    {
        //Delete this if not seems to be needed
        //IEnumerable<Geoname> GetGeonames(string startsWith, string country, int maxRows);

        IEnumerable<Forecast> RefreshForecast(string lat, string lon);
    }
}
