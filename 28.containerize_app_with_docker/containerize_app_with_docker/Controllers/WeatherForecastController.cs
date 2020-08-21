using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace containerize_app_with_docker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "abc"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // important links
            // https://docs.docker.com/engine/examples/dotnetcore/
            // https://medium.com/@oluwabukunmi.aluko/dockerize-asp-net-core-web-app-with-multiple-layers-projects-part1-2256aa1b0511

            /*
             * The commands             
             * docker build -f containerize_app_with_docker/Dockerfile -t the_experiment2 .
             * docker run -d -p 8080:80 --name myapp the_experiment2
             */

            var test = Class1.MyProperty;
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
