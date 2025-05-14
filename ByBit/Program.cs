using System.Threading.Tasks;
using bybit.net.api.Models.Market;
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
await RunBybitBotAsync(app.Services, cts);

await app.RunAsync();

static async Task RunBybitBotAsync(IServiceProvider hostProvider, CancellationTokenSource cts)
{
    var bybitClient = hostProvider.GetRequiredService<IBybitClient>();
    var result = await bybitClient.GetKlinesAsync("BTCUSD", MarketInterval.Daily);
}