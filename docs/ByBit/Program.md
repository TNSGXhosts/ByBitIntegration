# Program.cs

## 🐻 Initial Requirements

Tochka initializatsii da .$NET primennika, konfiguruets typicket web application cherez `WebApplication.createbBuilder` and unified exek.

- Starts binning configuration with `appsettings.json` and `EnvironmentVariables`
- Registers services via etenge `BybitIntegrationRegistry.RegisterBybitIntegrationServices`
- Builds and runs application with `RunAsync()`
- Calls castom async code method `RunBybitBotAsync()` with di-resolved client

---

## 📳 Technical Implementation

``c
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