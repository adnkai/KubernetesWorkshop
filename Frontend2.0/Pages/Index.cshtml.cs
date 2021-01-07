using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

using Frontend2._0.Models;

namespace Frontend2._0.Pages
{
    public class IndexModel : PageModel
    {
      private readonly ILogger<IndexModel> _logger;
      private WeatherForecast[] forecasts;
      public IndexModel(ILogger<IndexModel> logger)
      {
          _logger = logger;
      }

      public void OnGet()
      {
        HttpClient client = new HttpClient();
        forecasts = client.GetFromJsonAsync<WeatherForecast[]>("http://backend/weatherforecast").Result;
        // forecasts = client.GetFromJsonAsync<WeatherForecast[]>("http://51.145.190.137/weatherforecast").Result;
        
        ViewData["forecasts"] = forecasts;
      }
    }
}
