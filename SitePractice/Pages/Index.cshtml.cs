using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SitePractice.Models;
using SitePractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePractice.Pages
{
    public class IndexModel : PageModel
    {
        public List<Destination> Destinations { get; private set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileDestinationService _jsonFileDestinationService;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileDestinationService jsonFileDestinationService)
        {
            _logger = logger;
            _jsonFileDestinationService = jsonFileDestinationService;
        }

        public void OnGet()
        {
            Destinations = _jsonFileDestinationService.GetDestinations();
        }
    }
}
