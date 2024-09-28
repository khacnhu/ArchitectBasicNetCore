namespace Restaurants.API.Controllers
{
    public interface IWeatherForeCastService
    {
        IEnumerable<WeatherForecast> Get(int count, int min, int max);    
    }

    public class WeatherForeCastService : IWeatherForeCastService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int count, int mintemperature, int maxtemperature)
        {

            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(mintemperature, maxtemperature),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
