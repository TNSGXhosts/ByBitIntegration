# BybitClient.cs

## üêª Initial Requirements

This file implements a lightweight client wrapper around the official Bybit SDK services for integration into a .NET-based trading system. Its purpose is to:

- Initialize SDK client components (`SbybitMarketDataService` and `BybitTradeService`)
- Expose a simplified, testable method for retrieving candlestick (kline) data
- Prepare a base for extending trading and market operations

The client automatically read the Bybit configuration from `ICFonfiguration` via DI.


---

## ‚Üì Technical Implementation

### Namespace

`charp
namespace Axi.Bybit
c`

### Dependencies

- `bybit.net.api.ApiServiceImp`
- `bybit.net.api.Models`
- `Microsoft.Extensions.Configuration`
- `newtonsoft.json`

### Class: `BybitClient`
Responsible for wrapping Bybit services.

Privately initializes:

- BybitMarketDataService for reading kline data
- BybitTradeService for trading orders

Environment values is retrieved from `Microsoft.Extensions.Configuration`:

- BYRBIT_API_KEY
 - BYRBIT_API_SECRET
 - BYRBIT_USE_TESTNET

Structure: singleton di component without external resources.

### Method: `GetKlinesAsync`

``csharp
public async Task<List<KlineDto>> GetKlines@≥ync(string symbol, MarketInterval interval, int limit)
```

Retrieves candlestick data for specified trading pair and interval.

Uses `Category.SOT`as market type.

Returns: `list<KlineDto>` or empty list if no response.

## ‡üìù Future Extensions

- Document interfaces if needed
- Add more methods with trading actions
- Centralize error handling and exception management
