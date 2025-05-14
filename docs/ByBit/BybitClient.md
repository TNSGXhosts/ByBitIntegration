## Method: GetKlinesAsync

This method is the core public async method of the `BybitClient` class. Its intent is to retrieve candlestick information from the bybit api.

Signature:

```cs
nopublic async Task<List<KlineDto>> GetKlines@³ync(string symbol, MarketInterval interval, int limit);
```

Parameters:

- `symbol`: trading symbol ex. "BTCUSDT"
- `interval`: granularity for klines eg. "1M", "1H*
- `limit`: number of entries to return

Behaviour:

- Calls `_market` service and passes parameters
- Streams response into JSON
- Deserializes items to typed `KlineDto` representation
- Returns empty list on errors or null
