using Microsoft.AspNetCore.Mvc;

namespace Calculatrice_RPN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatriceRPN : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CalculatriceRPN> _logger;

        public CalculatriceRPN(ILogger<CalculatriceRPN> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Calculatrice_RPN> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Calculatrice_RPN
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}