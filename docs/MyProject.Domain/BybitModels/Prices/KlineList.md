# KlineList.cs

# 🐳 Initial Requirements

Class modeliruet ottvet Spot-stylem svecheyi api Bybit.

- Format response via json with field "list"
- Each entry is a timed kline kandle (precised chart)

---

## 📳 Technical Implementation

``c
using Newtonsoft.Json;

namespace BybitModels {

    public class KlineList
    {
        [JsonProperty("list")]
        public required List<Kline> Klines { get; set; }
    }

    public class Kline
    {
        public long Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal Turnover { get; set; }
    }
}
```

## 👏 Use in the project

- Response model for `GetKlinesAsync`
- Parsed from json with `FromJson`
