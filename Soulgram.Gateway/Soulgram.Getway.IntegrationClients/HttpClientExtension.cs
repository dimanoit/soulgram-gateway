using System.Text.Json;

namespace Soulgram.Getway.IntegrationClients;

public static class HttpClientExtension
{
    public static async Task<T> GetHttpResult<T>(
        this HttpClient client,
        string uri,
        CancellationToken cancellationToken)
    {
        var response = await client.GetAsync(uri, cancellationToken);

        return await response.DeserializeStringAsync<T>(cancellationToken)
               ?? throw new InvalidOperationException();
    }

    private static async Task<T?> DeserializeStringAsync<T>(
        this HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode) throw new HttpRequestException();

        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonSerializer.Deserialize<T>(responseJson, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}