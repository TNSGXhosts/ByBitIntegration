# IBybitClient.cs

# 🐳 Initial Requirements

Interfeis for
 - asynchronous retrieval of klynes data
- supports configuration-free abstraction
- intended to be used with DI/mocks/tests

 ---

```c
uses Bybit.net.api.Models.Market;
uses BybitModels;

namespace Bybit.BybitClient;

public interface IBybitClient
{
    Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);
}
```

## 📓 Contract Method

```public Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);```

- Asynchronny contract
- Returns `list of `KLINE`, representing candlestick data
- Parameters:
  * symbol: bybit symbol explicit
  * interval: market interval type
  * limit: limit of records

## 🌹 PlaceOrderAsync Method

```public Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);```

-  **Purpose**: Places a market order on Bybit using provided parameters.
- **Returns**: A [PlaceOrderResult] instance with Bybit's response.
- **Parameters**:
   - symbol: Market symbol (e.g. BTCUSDT)
   - side: `KUID | SELL*/
   - orderType: Type of the order (e.g. MARKET)\n   - qty: Decimal quantity to place

## 🐐 Integration

Realized by [BybitClient](BybitClient.md)
- Dependency Injection in BybitIntegrationRegistry.cs
