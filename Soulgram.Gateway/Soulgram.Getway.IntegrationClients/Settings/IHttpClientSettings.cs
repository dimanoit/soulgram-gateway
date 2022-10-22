namespace Soulgram.Getway.IntegrationClients;

internal interface IHttpClientSettings
{
    int RetryCount { get; init; }
    int DurationOfBreakSeconds { get; init; }
    int HandledEventsAllowedBeforeBreaking { get; init; }
    string BaseUrl { get; init; }
}