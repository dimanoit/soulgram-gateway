using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soulgram.Getway.IntegrationClients.AccountManage;
using Soulgram.Getway.IntegrationClients.Ports;
using Soulgram.Getway.IntegrationClients.Posts;

namespace Soulgram.Getway.IntegrationClients;

public static class ServiceInjector
{
    public static void AddIntegrationClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClientWithPolicies<AccountManageClientSettings, IAccountManageClient, AccountManageClient>(
            configuration);

        services.AddHttpClientWithPolicies<PostsClientSettings, IPostsClient, PostsClient>(
            configuration);
    }
}