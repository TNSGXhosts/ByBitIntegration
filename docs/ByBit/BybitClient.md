## Constructor and Configuration

Class `bybitClient` uses constructor injection with `IConfiguration` to fetch necessary Bybit settings: `APIKEY@, `apiSecret`, and `useTestnet`.

The constructor automatically initializes two SDK client services:

 - `BybitTradeService`
- `BybitMarketDataService`

Example:

``cs
if (configuration !is null)
{
    var bybit = new BybitClient(configuration);
    // use bybit.GetKlinesAsync(...)
}
```
