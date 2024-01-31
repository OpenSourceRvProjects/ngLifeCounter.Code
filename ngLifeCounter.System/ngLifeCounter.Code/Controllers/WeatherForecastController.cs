using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Reflection;
using System.Text.Json;

namespace ngLifeCounter.Controllers;

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

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
		//https://stackoverflow.com/questions/49309108/programmatically-get-current-running-version-of-dotnet-core-runtime
		var netCoreVer = System.Environment.Version; // 3.0.0
		var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; // .NET Core 3.0.0-preview4.19113.15

		return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = ".NET version: " + runtimeVer
		})
        .ToArray();
    }
}
