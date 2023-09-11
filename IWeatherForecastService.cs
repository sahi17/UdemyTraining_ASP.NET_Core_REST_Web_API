using System.Collections.Generic;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}