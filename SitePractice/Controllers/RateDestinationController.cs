using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePractice.Models;
using SitePractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SitePractice.Controllers
{
    [Route("/destinations")]
    [ApiController]
    public class RateDestinationController : ControllerBase
    {
        private readonly JsonFileDestinationService _destinationService;

        public RateDestinationController(JsonFileDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public List<Destination> Get()
        {
            return _destinationService.GetDestinations();
        }

        [HttpPost]
        [Route("/rate")]
        public ActionResult Get(RatingRequest body)
        {
            try
            {
                if (body.Rating <= 10 && body.Rating >= 1)
                {
                    _destinationService.AddRating(body.DestinationId, body.Rating);
                    return Ok();
                }
                else
                {
                    return BadRequest("The rating must be between 1 and 10!");
                }
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
    }
}
