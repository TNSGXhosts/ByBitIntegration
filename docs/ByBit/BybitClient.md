# BybitClient.cs

## 🐻 Initial Requirements

This file implements a lightweight client wrapper around the official Bybit SDK services for integration into a .NET-based trading system. Its purpose is to:

- Initialize SDK client components (`SbybitMarketDataService` and `BybitTradeService`)
- Expose a simplified, testable method for retrieving candlestick (kline) data
- Prepare a base for extending trading and market operations

It allows toggle between live and testnet environments and returns typed deserialized results from the Bybit API.

---

## 🔢 Technical Implementation

### ↓ Namespace

`charp
namespace Axi.Bybit
c`
J
### ↓ Dependencies

The class uses the following SDK and framework namespaces:

- `bybit.net.api.ApiServiceImp`
- `bybit.net.api.Models`
- `bybit.net.api.Models.Market`
- `Newtonsoft.Json`

### ↓ Class: `BybitClient`

a  public class that encapsulates the SDK services for:

- ** Market data (`_market`) via `BybitMarketDataService`
- **Trade operations (`_trade`) via `BybitTradeService`

### Constructor

``charp
public BybitClient(string apiKey, string apiSecret, bool useTestnet)
```

Initializes both the market and trade service instances with API credentials and environment mode:

- `apiKey`: Public API key from Bybit
- `apiSecret`: Corresponding secret key
- `useTestnet`: Boolean flag to toggle between live and testnet endpoints

The services are configured with `debugMode` set according to the `useTestnet` flag.

### Method: `GetKlinesAsync`

`charp
public async Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)
```

This method fetches historical candlestick (kLine) data for a specified symbol and time interval:

- `symbol`: Trading pair (e.g. `BTCUSDT`)
- `interval`: Enum indicating the granularity of each kline (e.g., 1m, 5m, 1h)
- `limit`: Maximum number of klines to retrieve

Returns: `List<KlineDto>` “ typed DTOs representing each kline entry.

Implementation Notes:
- Uses `GetMarketKline` from `_market`
- Converts raw JSON to `KlineListDto` and extracts `.Klines`
- Returns an empty list on null response

### 💫 Testability

- Internally decouples market and trade service usage
- Exposes simple methods for mocking during unit tests
- Configurable environment for development vs production

### 📝 Future Extensions

- Add `PlaceOrderAsync(...)` for executing market orders
- Support more endpoints (e.g., order book, account info)
- Centralize error handling and logging