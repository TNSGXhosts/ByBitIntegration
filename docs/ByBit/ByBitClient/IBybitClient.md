# IBybitClient.cs

# 🐳 Initial Requirements

Interface for bybit client that defines market operations from the application.

- Fetches klynes asynchronously
- Places orders defined by side,type,aqt
\n### Methods

``cc
// Retrieves reserved market data with optional limit
Async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null);

// Places a market order using specified parameters: symbol, side, orderType, qty
Async Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
```

### Notes
- Method `getKaninesAsync` now supports `limit` as optional parameter
- Response type updated to use `KlineResponse` instead of `KlineList`
parsing full with `JSONConverter
 - Adjusted comments for better autocompletion

### Integration
Best used with DI in consumer services and view testing through IBybitClient with mocks.
