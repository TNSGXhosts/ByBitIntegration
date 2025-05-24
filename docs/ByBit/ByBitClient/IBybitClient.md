# IBybitClient

`IBybitClient` describes the minimal set of operations required by the application. It deliberately exposes only a subset of the v5 REST API.

## Methods
### GetKlinesAsync
```csharp
Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null);
```
Returns historical market klines for the specified symbol. `MarketInterval` corresponds to Bybit v5 interval values (e.g. `1`, `3`, `D` etc.).

### PlaceOrderAsync
```csharp
Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
```
Creates a spot order. Only the main fields are exposed; additional optional parameters can be added to the client implementation if required.

### GetWalletBalanceAsync
```csharp
Task<IEnumerable<WalletBalance>> GetWalletBalanceAsync(AccountType accountType);
```
Retrieves account balances for the given account type (`AccountType.Unified` for v5 accounts).
