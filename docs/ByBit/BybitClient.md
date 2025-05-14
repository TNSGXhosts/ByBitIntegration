# BybitClient.cs

## 🌹 Initial Requirements

This class is a simplified adapter over the official Bybit `.NET` SDK. It centralizes interaction logic with the market data and order execution services, specifically for use in a trading application or a data consumer.

The primary requirement is to allow easy configuration (via API key, secret, and testnet usage flag) and abstract the interaction with:
- The public market data service (`BybitMarketDataService`)
- The trading operations service (`BybitTradeService`)

## 👋 Technical Implementation

### 🙶 Dependencies
- `bybit.net.api` "• Communicates with Bybit exchange API
- `Newtonsoft.Json` • Used for deserialization of raw JSON responses

### 😋Namespace
`csharp
namespace Axi.Bybit
```

### 🜹 Constructor

```csharp
public BybitClient(string apiKey, string apiSecret, bool useTestnet)
```

Initializes two Bybit SDK services: 
- `BybitMarketDataService` for fetching market candles (klines)
- `BybitTradeService` for placing orders

All services are instantiated with the same credentials and testnet flag.

### 🜳 Method: `GetKlinesAsync`

``csharp
public async Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)
```

- **Purpose**: Fetches historical candlestick data (open, high, low, close, volume)
- **Returns**: A list of `KlineDto` objects.
- **Parameters**:
  - `symbol`: trading pair (e.g. `BTCUSDT`)
  - `interval`: enum representing candle timeframe (e.g. `oneMinute`)
  - `limit`: number of candles to retrieve

“Logic:”
1. Calls `GetMarketKline` from the market service.
2. Deserializes the raw JSON response into a typed `KlineListDto ` object.
3. Returns the `.Klines` property if successful, or an empty list otherwise.
---

What's next?
\n**\ Continue to next documentation?\n*** Type \"yes\" to continue with related files.