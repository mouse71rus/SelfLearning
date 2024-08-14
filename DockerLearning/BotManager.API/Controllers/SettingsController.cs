using Microsoft.AspNetCore.Mvc;

namespace BotManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly string _secretKey;

        public SettingsController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _secretKey = configuration.GetValue<string>("SecretKey");
        }

        [HttpGet]
        [Route("GetSecretValue/{key}")]
        public IActionResult GetSecretValue(string key)
        {
            return Ok($"{key}: {_secretKey}");
        }
    }
}