using Soulgram.Gateway.Domain;

namespace Soulgram.Getway.IntegrationClients.Ports;

public interface IPostsClient
{
    Task<PostsByIdResponse> GetPosts(
        PostsByUserIdRequest request,
        CancellationToken cancellationToken);
}