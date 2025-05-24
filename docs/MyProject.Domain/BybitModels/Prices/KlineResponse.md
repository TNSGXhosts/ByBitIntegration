# KlineResponse

Wrapper for the response returned by the Market Kline v5 endpoint. The `list` field from the API is converted to a collection of `Kline` objects using `KlineListConverter`.

```json
{
  "retCode": 0,
  "retMsg": "OK",
  "result": {
    "list": [ [<kline values>] ]
  }
}
```
