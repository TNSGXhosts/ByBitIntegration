# BybitClient
### Class description

@class: BybitClient
@description: Implementation of IBybitClient that provides asynchronous methods to interact with the bybit.net.api service api for market trading and order management.
## Constructor

 ```cs
bybitClient(IOptions<bybitSettings> options)
```

Takes the service settings and initializes the API key/secret in testnet or live mode.

## Methods

### GetKlinesAsync

```cs
Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null);
```

Retrieves market candlestick data (klines) from the Bybit API.

@aram type="string" name="symbol" description="The trading pair symbol"
`@return: Task<List<Kline>>

### PlaceOrderAsync

```cs
Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
```

Requests add orders for the specified symbol with side (Buy, Sell) and order type (Limit, Market, etc).

@aram type="string" name="symbol"
`@return: Task<PlaceOrderResult>
