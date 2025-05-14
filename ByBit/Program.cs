using Bybit;
using Bybit.BybitClient;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
builder.Services.RegisterBybitIntegrationServices(configuration);

var app = builder.Build();

using CancellationTokenSource cts = new();
RunBybitBotAsync(app.Services, cts);

await app.RunAsync();

static void RunBybitBotAsync(IServiceProvider hostProvider, CancellationTokenSource cts)
{
    var bybitClient = hostProvider.GetRequiredService<IBybitClient>();
}