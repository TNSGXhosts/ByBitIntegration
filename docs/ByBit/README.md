# BybitTradingClient

This solution provides a lightweight integration layer over the official [`bybit.net.api`](https://github.com/TraderGPT/bybit.net.api) library. It targets the Bybit **v5 REST API** and demonstrates how to consume market data, place orders and fetch account balances inside a .NET application.

The project is organised as a set of services that can be registered via dependency injection. All examples use the Bybit testnet URL by default.

## Features
- Retrieve market klines (candlesticks) for inverse/USDT perpetual symbols
- Place spot market orders
- Query unified account balances

## Getting started
1. Install the `bybit.net.api` package:

```bash
 dotnet add package bybit.net.api
```

2. Create an `appsettings.json` containing API credentials and whether to use the testnet:

```json
{
  "BybitSettings": {
    "ApiKey": "<your key>",
    "SecretKey": "<your secret>",
    "UseTestnet": true
  }
}
```

3. Register the integration services and resolve `IBybitClient` from DI.

```csharp
builder.Services.RegisterBybitIntegrationServices(configuration);
var client = host.Services.GetRequiredService<IBybitClient>();
```

See the documentation for each component under [`docs/ByBit`](./) for more details.
