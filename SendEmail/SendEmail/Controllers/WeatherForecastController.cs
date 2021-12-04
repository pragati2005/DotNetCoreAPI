using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendEmail.Models;
using SendEmail.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SendEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SendEmail.Repository.IEmailSender _emailsender;

        private static readonly string[] Summaries = new[]
        {

            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(SendEmail.Repository.IEmailSender emailsender, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _emailsender = emailsender;
        }
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var message = new Message(new string[] { "pragati11102268@gmail.com" }, "Test email async", "This is the content from our async email.");
            await _emailsender.SendEmailAsync(message);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

       
    }
}
