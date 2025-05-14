# Kline.cs
 
### Initial Requirements
 Class `kline` predstavlena sdata of candlestick history data fetched from Bybit Market API.

- `Timestamp`: unix time in ms
- `Open`, `High`, `Low`, `Close`: price off the interval
- `Volume`, `Turnover`: amounts traded

### Technical Implementation
*- Mutable data container with {set; get;}
*- Fields are readble from JSON/response
----

 ```cs
nlass0Kline
{
  public long Timestamp  { get; set; }
  public decimal Open { get; set; }
  public decimal High { get; set; }
  public decimal Low { get; set; }
  public decimal Close { get; set; }
  public long Volume { get; set; }
  public decimal Turnover { get; set; }
}
```
