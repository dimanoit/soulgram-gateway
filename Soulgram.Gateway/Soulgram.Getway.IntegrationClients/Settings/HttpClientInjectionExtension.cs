using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Soulgram.Getway.IntegrationClients;

[ExcludeFromCodeCoverage]
public static class HttpClientInjectionExtension
{
    // Circuit Breaker on Polly https://github.com/App-vNext/Polly/wiki/Circuit-Breaker
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(
        int durationOfBreakSeconds,
        int handledEventsAllowedBeforeBreaking)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(durationOfBreakSeconds));
    }

    // Retry with exponential backoff on Polly https://github.com/App-vNext/Polly/wiki/Retry 
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryCount,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    internal static void AddHttpClientWithPolicies<T, TInterface, TClient>(
        this IServiceCollection services,
        IConfiguration configuration)
        where T : IHttpClientSettings
        where TInterface : class
        where TClient : class, TInterface
    {
        var clientSettings = configuration
            .GetSection(typeof(T).Name)
            .Get<T>();

        var retryPolicy = GetRetryPolicy(clientSettings.RetryCount);
        var circuitBreakerPolicy = GetCircuitBreakerPolicy(
            clientSettings.DurationOfBreakSeconds,
            clientSettings.HandledEventsAllowedBeforeBreaking);

        var siteUrl = clientSettings.BaseUrl;

        services.AddHttpClient<TInterface, TClient>(
                client => { client.BaseAddress = new Uri(siteUrl); })
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(circuitBreakerPolicy);
    }
}