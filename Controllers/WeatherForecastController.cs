using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }

        [HttpGet("currentDay/{max}")]
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401; //sposób pierwszy
            //return $"Hello {name}";

            //return StatusCode(401, $"Hello {name}"); //sposób drugi

            return NotFound($"Hello {name}");
        }

        [HttpPost("generate/")]
        public ActionResult<String> Generate([FromQuery] int results, [FromBody] TemperatureRequest request)
        {
            if ((results < 0) || (request.Min > request.Max))
            {

                return BadRequest();
            }

            var result = _service.Get(results, request.Min, request.Max);

            return Ok(result);
        }
    }
}
