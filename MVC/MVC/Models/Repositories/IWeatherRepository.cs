﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Repositories
{
    public interface IWeatherRepository : IDisposable
    {
        /* Deletet Geonoame?
        //CRUD Geoname
        IEnumerable<Geoname> FindAllGeonames();
        Geoname FindGeonameById(int id);
        void AddGeoname(Geoname geoname);
        void UpdateGeoname(Geoname geoname);
        void RemoveGeoname(int id);
        */

        //CRUD Forecast
        IEnumerable<Forecast> FindAllForecasts();
        Forecast FindForecastById(int id);

        // Delete ??
        //IEnumerable<Forecast> FindForecastsByGeonameID(string id);

        void AddForecast(Forecast forecast);
        void UpdateForecast(Forecast forecast);
        void RemoveForecast(Forecast forecast);

        void Save();
    }
}
