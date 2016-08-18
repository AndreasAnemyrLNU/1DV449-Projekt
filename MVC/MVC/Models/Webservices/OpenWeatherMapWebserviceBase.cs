﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Webservices
{
    public abstract class OpenWeatherMapWebserviceBase : IOpenWeatherMapWebservice
    {
        public abstract IEnumerable<Forecast> Get5DaysForecastByCityId(string lat, string lon);
    }
}
