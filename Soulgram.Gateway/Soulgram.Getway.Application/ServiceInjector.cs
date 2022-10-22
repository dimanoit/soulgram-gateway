using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.Getway.Application;

public static class ServiceInjector
{
    public static void AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRelatedPostsService, UserRelatedPostsService>();
    }
}