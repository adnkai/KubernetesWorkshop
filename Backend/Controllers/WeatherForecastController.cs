using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
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

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      
      var stuff = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
      
      var stuff2 = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();

      try
      {
        WriteFile("myfile.txt", stuff);
        WriteFile2("myfile.txt", stuff2);
      }
      catch(Exception){}
      
      return stuff;  
    }

    private void WriteFile(string filename, IEnumerable<WeatherForecast> stuff) {
      string path = "/mnt/azure/";
      using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(path+filename, true))
      {
        foreach (WeatherForecast line in stuff)
        {
          file.WriteLine("DYNAMIC SHARE: " + line.ToString());
        }
      }
    }

    private void WriteFile2(string filename, IEnumerable<WeatherForecast> stuff) {
      string pathStatic = "/mnt/azureStatic/";
      
      using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(pathStatic+filename, true))
      {
        foreach (WeatherForecast line in stuff)
        {
          file.WriteLine("STATIC SHARE: " + line.ToString());
        }
      }
    }
  }
}
