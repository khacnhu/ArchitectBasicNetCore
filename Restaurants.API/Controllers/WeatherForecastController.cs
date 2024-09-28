using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;


public class TemperatureRequest
{
    public int Min { get; set; }
    public int Max { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForeCastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForeCastService weatherForeCastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForeCastService;
    }

    [HttpPost("create")]
    public IActionResult Generate([FromQuery]int count, [FromBody]TemperatureRequest request)
    {
        if(count < 0 || request.Max < request.Min)
        {
            return BadRequest("Count has to be positive number, and max < min");
        }
        
        var res =  _weatherForecastService.Get(count, request.Min, request.Max);
        return Ok(res);
    }


    //[HttpGet]
    //[Route("example")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    var result = _weatherForecastService.Get();
    //    return result;
    //}

    //[HttpGet("currentday")]
    //public WeatherForecast GetCurrentDay()
    //{
    //    var result = _weatherForecastService.Get().FirstOrDefault();
    //    return result;
    //}

    //[HttpGet]
    //[Route("{take}/example")]
    //public string Get([FromQuery]int max, [FromRoute]int take)
    //{
        
    //    return $" Max = {max} ------ Take = {take} ";
    //}


    //[HttpPost]
    //public string CreateWeather()
    //{

    //    return "Create Weather Successfully";
    //}


    

    
    

    


}
