using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test : ControllerBase
    {
        private CompanyContext _ctx;
        public Test(CompanyContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("api/test")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
