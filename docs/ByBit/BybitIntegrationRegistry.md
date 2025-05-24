# BybitIntegrationRegistry

`BybitIntegrationRegistry` is a helper class that wires up the client and configuration using Microsoft.Extensions.DependencyInjection. It exposes one extension method used at application startup.

## RegisterBybitIntegrationServices
```csharp
void RegisterBybitIntegrationServices(this IServiceCollection services, IConfigurationRoot configuration);
```
- Binds the `BybitSettings` section from configuration.
- Adds `IBybitClient` as a singleton service.
- Enables in-memory caching for the underlying API service.

Call this method in your startup code before resolving `IBybitClient`.
