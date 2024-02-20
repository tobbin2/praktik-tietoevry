using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.Sensor;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
            

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<GetWeatherForecast.Result> Get([FromQuery] GetWeatherForecast.Query query)
        {
            return await _mediator.Send(query);
        }
    }
}