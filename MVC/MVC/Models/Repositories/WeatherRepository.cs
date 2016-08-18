using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Repositories
{
    public class WeatherRepository : WeatherRepositoryBase
    {
        public WeatherRepository(WebAppContext webAppContext)
        {
            this._context = webAppContext;
        }

        private WebAppContext _context;

        // Forecast
        protected override IQueryable<Forecast> QueryForecasts()
        {
            return _context.Forecasts.AsQueryable();
        }

        public override void AddForecast(Forecast forecast)
        {
            _context.Forecasts.Add(forecast);
        }

        public override void UpdateForecast(Forecast forecast)
        {
            _context.Entry(forecast).State = EntityState.Modified;
        }

        public override void RemoveForecast(Forecast forecast)
        {
            forecast = _context.Forecasts.Find(forecast.forecastId);
            _context.Forecasts.Remove(forecast);
        }

        // Context
        public override void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;

            base.Dispose(disposing);
        }

        #endregion
    }
}
