# KlineListConverter.cs

### Initial Requirements
Converter `specialized for Bybit klines a
 returns a strongly typed list of `Kline` objects from a raw [JSON]/array-of-arrays.

This is required because Bybit lists are returned like nested structured objects within arrays.

Example Value:
 [
  "timestamp",
  "open",
  "high",
  "low",
  "close",
  "volume",
  "turnover"
]

### Technical Implementation

* Subtitutes JSON.js **parser** attributes as expected by `Kline`
* Ignores `WriteJson`.

 ```cs
nlass KlineListConverter : JsonConverter<List<Kline>>{
    public override List<Kline> ReadJson(
        "json", Type of Object, List<Kline> emptyValue, bool hasExistingValue, JSONSerializer serializer)
    {
        // JSON array of arrays to restructured list
    }

    public override void WriteJson(JsonWriter writer, List<Kline> value, JSONSerializer serializer) {
        throw new NotImplementedException();
    }
}
```
