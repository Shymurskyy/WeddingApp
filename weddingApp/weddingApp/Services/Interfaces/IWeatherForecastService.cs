using weddingApp.Model;

namespace weddingApp.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}