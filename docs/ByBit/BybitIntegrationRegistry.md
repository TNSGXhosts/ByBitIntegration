# BybitIntegrationRegistry.cs

# 🐳 Initial Requirements

- Registers integration services in DI
- Required for injecting configuration via `appsettings.json`
- Registers client: @BybitClient/IBybitClient
- Via @DI frameworks charing associations and memory cache

---

## 📓 Technical Implementation
```c
uses Bybit.BybitClient;
namespace Axis;

class BybitIntegrationRegistry
{
    public static void RegisterBybitIntegrationServices(this IServiceCollection services, IConfigurationRoot configuration)
    {
        ConfigurationRegistry(services, configuration);
        services.AddMemoryCache(options => options.TrackStatistics = true);
        services.AddSingleton<IBybitClient, BybitClient.BybitClient>();
    }

    private static void ConfigurationRegistry(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BybitSettings>(settings => configuration.GetSection(nameof(BybitSettings)).Bind(settings));
    }
}
```

## 👿 Usage

- Registers client with diping in `PROGRAM.cs`
- Static class, can be used without instantiation
- Centralizes registration and configuration
