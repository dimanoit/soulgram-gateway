using Soulgram.Gateway.Domain;
using Soulgram.Getway.IntegrationClients.Ports;

namespace Soulgram.Getway.Application;

public class UserRelatedPostsService : IUserRelatedPostsService
{
    private readonly IAccountManageClient _accountManageClient;
    private readonly IPostsClient _postsClient;

    public UserRelatedPostsService(IPostsClient postsClient, IAccountManageClient accountManageClient)
    {
        _postsClient = postsClient;
        _accountManageClient = accountManageClient;
    }

    public async Task<PostsByIdResponse> GetUserMatesPosts(
        string userId,
        CancellationToken cancellationToken)
    {
        var userIdPageRequest = new UserIdPageRequest
        {
            UserId = userId
        };

        var userMatesIds = await _accountManageClient
            .GetUserMatesIds(userIdPageRequest, cancellationToken);

        var postsByUserIdRequest = new PostsByUserIdRequest
        {
            CurrentUserId = userId,
            UsersIds = userMatesIds.Data.ToArray()
        };

        var posts = await _postsClient.GetPosts(postsByUserIdRequest, cancellationToken);
        return posts;
    }
}