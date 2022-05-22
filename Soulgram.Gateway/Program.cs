using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureLogging((_, logging) => logging.ClearProviders())
    .UseSerilog();

builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));


var app = builder.Build();
app.UseRouting();
app.UseCors("MyPolicy");
app.UseOcelot();
app.MapGet("/", () => "Hello World!");
app.Run();