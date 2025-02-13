using System.Net.Http.Headers;

namespace Supporter_Uno.Services.Endpoints;

internal class DebugHttpHandler : DelegatingHandler
{
    private readonly ILogger _logger;
    private readonly ITokenCache authenticationTokenProvider;
    private readonly IDispatcher dispatcher;

    public DebugHttpHandler(
        ILogger<DebugHttpHandler> logger,
        ITokenCache tokenCache,
        HttpMessageHandler? innerHandler = null
    )
        : base(innerHandler ?? new HttpClientHandler())
    {
        _logger = logger;
        this.authenticationTokenProvider = tokenCache;
    }

    private async Task<AuthenticationHeaderValue?> GetTokenAsync(
        CancellationToken cancellationToken
    )
    {
        string token = await authenticationTokenProvider.AccessTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            token = await authenticationTokenProvider.AccessTokenAsync();
        }
        return new AuthenticationHeaderValue("Bearer", token);
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        request.Headers.Authorization = await GetTokenAsync(cancellationToken);
        Console.WriteLine($"Authorization-Header: {request.Headers.Authorization}");
        var response = await base.SendAsync(request, cancellationToken);
#if DEBUG
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogDebugMessage("Unsuccessful API Call");
            if (request.RequestUri is not null)
            {
                _logger.LogDebugMessage($"{request.RequestUri} ({request.Method})");
            }

            foreach (
                (var key, var values) in request.Headers.ToDictionary(
                    x => x.Key,
                    x => string.Join(", ", x.Value)
                )
            )
            {
                _logger.LogDebugMessage($"{key}: {values}");
            }

            var content = request.Content is not null
                ? await request.Content.ReadAsStringAsync()
                : null;
            if (!string.IsNullOrEmpty(content))
            {
                _logger.LogDebugMessage(content);
            }

            // Uncomment to automatically break when an API call fails while debugging
            // System.Diagnostics.Debugger.Break();
        }
#endif
        return response;
    }
}
