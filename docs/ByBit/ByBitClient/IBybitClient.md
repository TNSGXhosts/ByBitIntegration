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

## 🐐 Integration

Realized by [BybitClient](BybitClient.md)
- Dependency Injection in BybitIntegrationRegistry.cs
