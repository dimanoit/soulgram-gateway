using Ocelot.DependencyInjection;
using Soulgram.Logging;
using Soulgram.Logging.Models;

namespace Soulgram.Gateway;

public static class ServiceInjector
{
    public static IServiceCollection AddUi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOcelot(configuration);
        services.AddHealthChecks();
        services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        var loggingSettings = configuration
            .GetSection("LoggingSettings")
            .Get<LoggingSettings>();

        return services.AddLogging(loggingSettings);
    }
}