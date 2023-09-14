using System.Collections.Generic;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> Get(int resultNumber, int minTemperature, int maxTemperature);
    }
}