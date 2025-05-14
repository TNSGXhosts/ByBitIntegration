
namespace Bybit;

public static class BybitIntegrationRegistry
{
    public static void RegisterBybitIntegrationServices(this IServiceCollection services, IConfigurationRoot configuration)
    {
        ConfigurationRegistry(services, configuration);

        services.AddMemoryCache(options => options.TrackStatistics = true);

        services.AddSingleton<IBybitClient, BybitClient>();
      }


    private static void ConfigurationRegistry(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BybitSettings>(settings => configuration.GetSection(nameof(BybitSettings)).Bind(settings));
    }
}
