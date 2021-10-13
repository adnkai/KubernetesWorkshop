using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend2._0.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly ILogger<HistoryModel> _logger;

        public HistoryModel(ILogger<HistoryModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
          ReadFile("myfile.txt");
        }
        private void ReadFile(string filename) {
          string path = "/mnt/volumeMountSsd/";
          string pathStatic = "/mnt/volumeMountHdd/";
          
          ViewData["lines"] = System.IO.File.ReadAllLines(path+filename);
          ViewData["linesStatic"] = System.IO.File.ReadAllLines(pathStatic+filename);
        }
    }
}
