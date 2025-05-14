# BybitTradingClient Adapter

A thin DI‑friendly adapter over the **official Bybit .NET SDK (`bybit.net.api`)**.  
Provides only two sample operations – fetching klines and placing orders – but is easily extensible.

## Setup

```bash
dotnet add package bybit.net.api
```

Place **`BybitClient.cs`** into your project (for example, in `AlgoTrading/Bybit/`), then register:

```csharp
services.AddBybitTradingClient(o =>
{
    o.ApiKey    = Environment.GetEnvironmentVariable("BYBIT_API_KEY")!;
    o.ApiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET")!;
    o.UseTestnet = true;               // false for Mainnet
});
```

## Usage

```csharp
var client = provider.GetRequiredService<IBybitTradingClient>();

// candles
var klines = await client.GetKlinesAsync("BTCUSDT", MarketInterval.OneMinute);

// market order
await client.PlaceOrderAsync("BTCUSDT", Side.BUY, OrderType.MARKET, qty: "0.001");
```

## Extending

Add more methods in `IBybitTradingClient` and forward them to the corresponding services of the SDK (`BybitAccountService`, `BybitPositionService`, etc.).
