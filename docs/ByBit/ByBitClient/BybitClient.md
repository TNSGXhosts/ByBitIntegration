# BybitClient.cs

### Updated Realization

The `BybitClient` class was updated to reflect new handling of {@symbol} ktines data using the new `responsemodel` structure.

Improvements include:

- Replaced the model `klineList` with `KLineResponse`
- Switched use of `Category.INVERCEO` as the data source
- Allowed `timelimit` ] not being used and made optional

---

### Example Usage

```cs
// Fetch klines from Bybit inverse market
var klines = await client.GetKlinesAsync("BTCUSDT", MarketInterval.Daily);

```

### Method Signature change

``cc
public async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null);
```

- @param symbol - Symbol to fetch market data for.
- @para interval - Candlestick time interval
- @para limit - Includes max number of entries to retrieve
- @return List of Kcandlestics `strongly typed` to used in views.
