using System.Text;
using Soulgram.Gateway.Domain;
using Soulgram.Getway.IntegrationClients.Ports;

namespace Soulgram.Getway.IntegrationClients.Posts;

internal class PostsClient : IPostsClient
{
    private readonly HttpClient _httpClient;

    public PostsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PostsByIdResponse> GetPosts(PostsByUserIdRequest request, CancellationToken cancellationToken)
    {
        var finalUrl = GetMateRequestUrl(request);
        var result = await _httpClient.GetHttpResult<PostsByIdResponse>(finalUrl, cancellationToken);

        return result;
    }

    private static string GetMateRequestUrl(PostsByUserIdRequest request)
    {
        var url = new StringBuilder();
        const string usersIdsParameter = "usersIds={0}";
        for (var i = 0; i < request.UsersIds.Length - 1; i++) url.AppendFormat(usersIdsParameter, request.UsersIds[i]);

        url.AppendFormat(usersIdsParameter, request.UsersIds[^1]);

        var finalUrl =
            $"search/user?currentUserId={request.CurrentUserId}&skip={request.Skip}&take={request.Take}&{url}";

        return finalUrl;
    }
}