# PlaceOrderResult

Result model representing order ID/link returned from bybit.

Typicallly returned from `PlaceOrderAsync` call reads this as:

```cs
class PlaceOrderResult {
    public required string OrderId  { get; set; }
    public required string OrderLinkId { get; set; }
}
```

## Usage

Instance of this class is returned from valid create/place order request.
