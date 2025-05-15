# Program.cs

### Initialization and Run
The application entrypoint sets up an async WebApplication with configuration files, registers services and runs functional code.

```c
builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.RegisterBybitIntegrationServices(configuration);

var app = builder.Build();

using CancellationTokenSource cts = new();
RunBybitBotAsync(app.Services, cts);

await app.RunAsync();

async Task RunBybitBotAsync(IServiceProvider hostProvider, CancellationTokenSource cts)
{
    var client = hostProvider.GetRequiredService<IBybitClient>();
    var result = await client.GetKlinesAsync("BTCUSD", MarketInterval.Daily);
}
```
