using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deployment.Controllers
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

        [HttpGet()]
        public IActionResult Health()
        {
            return Ok(Summaries);
        }

        [HttpGet("Error")]
        public IActionResult NotRunning()
        {
             Response.StatusCode = 400;
            return Content("Naughty");
        }

        [HttpGet("Result")]
        public IActionResult Get()
        {
            return Ok("Green");
        }
    }
}
