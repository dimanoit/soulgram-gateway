namespace Soulgram.Getway.IntegrationClients;

public class PostsClientSettings : IHttpClientSettings
{
    public int RetryCount { get; init; }
    public int DurationOfBreakSeconds { get; init; }
    public int HandledEventsAllowedBeforeBreaking { get; init; }
    public string BaseUrl { get; init; }
}