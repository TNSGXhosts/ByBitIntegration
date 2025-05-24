# Program.cs

The example program demonstrates how to configure the client inside an ASP.NET style host. It loads configuration, registers the integration and fetches daily klines for `BTCUSD`.

```csharp
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

static async Task RunBybitBotAsync(IServiceProvider services, CancellationTokenSource cts)
{
    var client = services.GetRequiredService<IBybitClient>();
    var klines = await client.GetKlinesAsync("BTCUSD", MarketInterval.Daily);
}
```
