using demoapp.DbHandler;
using demoapp.Model;
using Microsoft.AspNetCore.Mvc;

namespace demoapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public dataModel Get()
        {
            dataModel model = new dataModel();
            DataDBhandler db = new DataDBhandler();
            model = db.fetchdatafromdatabase();
            return model;
        }
    }
}
