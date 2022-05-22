using Soulgram.Logging;
using Soulgram.Logging.Models;

namespace Soulgram.Gateway;

public static class ServiceInjector
{
    public static IServiceCollection AddLogging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var loggingSettings = configuration
            .GetSection("LoggingSettings")
            .Get<LoggingSettings>();

        return services.AddLogging(loggingSettings);
    }
}