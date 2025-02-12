using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web.Resource;

namespace Supporter_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GraphServiceClient graphServiceClient;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            GraphServiceClient graphServiceClient
        )
        {
            _logger = logger;
            this.graphServiceClient = graphServiceClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var test = await graphServiceClient.Me.Request().GetAsync();
            var xyz = Guid.Parse(test.Id);
            var dsf = GetUserObjectId();
            var tenantId = User.FindFirst(
                "http://schemas.microsoft.com/identity/claims/tenantid"
            )?.Value;

            var user = this.User;
            return Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                })
                .ToArray();
        }

        public Guid GetUserObjectId()
        {
            var user = HttpContext?.User;
            return Guid.Parse(
                user?.FindFirst(
                    "http://schemas.microsoft.com/identity/claims/objectidentifier"
                ).Value
            );
        }
    }
}
