using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Domain.Sensor
{
    public class GetWeatherForecast
    {
        public class Result
        {
            public List<WeatherForecast> WeatherForecast { get; set; }
        }
        // Request class
        public class Query : IRequest<Result>
        {
            [Required]
            public string Data { get; set; }
        }

        // Request handler class
        public class Handler : IRequestHandler<Query, Result>
        {

            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            Task<Result> IRequestHandler<Query, Result>.Handle(Query request, CancellationToken cancellationToken)
            {

                var result = new Result
                {
                    WeatherForecast = Enumerable.Range(1, 5)
                        .Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                        )
                        .ToList()
                };

                return Task.FromResult(result);
            }
        }
    }
}
