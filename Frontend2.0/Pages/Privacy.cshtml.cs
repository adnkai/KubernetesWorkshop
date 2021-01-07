using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend2._0.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
          ViewData["lines"] = ReadFile("myfile.txt");
        }
        private string[] ReadFile(string filename) {
          string path = "/mnt/azure/";
          var lines = System.IO.File.ReadAllLines(path+filename);
          return lines;
        }
    }
}
