using System.Security.Claims;
using System.Text.Encodings.Web;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Graph.ExternalConnectors;

namespace Supporter_Api.Auth
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string ApiKeyHeaderName = "X-API-KEY";
        private string ExpectedApiKey; // Sicher speichern, z. B. in der Konfiguration

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IConfiguration configuration
        )
            : base(options, logger, encoder)
        {
            ExpectedApiKey = configuration.GetSection("ApiAuth")["ApiKey"];
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                return AuthenticateResult.Fail("API Key fehlt");
            }

            if (!ExpectedApiKey.Equals(extractedApiKey.FirstOrDefault()))
            {
                return AuthenticateResult.Fail("Ungültiger API Key");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, "API-Key-User") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
