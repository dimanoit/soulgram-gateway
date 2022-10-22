using Ocelot.Middleware;
using Serilog;
using Soulgram.Gateway;
using Soulgram.Getway.Application;
using Soulgram.Getway.IntegrationClients;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureLogging((_, logging) => logging.ClearProviders())
    .UseSerilog();

var configuration = builder.Configuration;
configuration.AddJsonFile("ocelot.json", false, true);

var services = builder.Services;
services.AddIntegrationClients(builder.Configuration);
services.AddApplication();
services.AddUi(configuration);

var app = builder.Build();
app.UseRouting();
app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.MapHealthChecks("/health");

app.MapGet("/user-posts/{userId}",
    async (IUserRelatedPostsService service, string userId) => await service.GetUserMatesPosts(userId, default));

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");
});
app.UseOcelot()
    .Wait();

app.Run();