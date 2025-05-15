# BybitTradingClient

This repository contains a modern .NET Client adapter for the Bybit API ( ` bybit.net.api` `).

This integration supports two main operations:

- Getting market kline data (using `GetKlinesAsync`)
- Placing market orders (using `PlaceOrderAsync`)

Grounded to be simple, extensible, and suitable for live and testnet trading scenarios.

## Installation

``b
dotnet install bybit.net.api
```


## Dependency Injection

Register the client via Service Collection.

Example:
```cs
services.RegisterBybitIntegrationServices(configuration);
```

## Usage

After registration, you can resolve IBybitClient from DI and use it to access Bybit:

```cs
var instance = host.provider.GetRequiredService<IBybitClient>();
var klines = await instance.GetKlinesAsync("symbol", MarketInterval.Daily);
```

