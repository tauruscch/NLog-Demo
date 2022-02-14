using Microsoft.AspNetCore.Mvc;

namespace NLog.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogTrace("测试日志 Trace");
            _logger.LogDebug("测试日志 Debug");
            _logger.LogInformation("测试日志 Info");
            _logger.LogWarning("测试日志 Warn");
            _logger.LogError("测试日志 Error");
            _logger.LogCritical("测试日志 Fatal");

            try
            {
                var a = 0;
                var b = 1 / a;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}