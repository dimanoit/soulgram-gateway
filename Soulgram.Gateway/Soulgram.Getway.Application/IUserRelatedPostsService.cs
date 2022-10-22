using Soulgram.Gateway.Domain;

namespace Soulgram.Getway.Application;

public interface IUserRelatedPostsService
{
    Task<PostsByIdResponse> GetUserMatesPosts(
        string userId,
        CancellationToken cancellationToken);
}