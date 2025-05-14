using Newtonsoft.Json;

namespace Bybit {
    public class KlineListDto {
        [JsonProperty("list")]
        public required List<KlineDto> Klines { get; set; }
    }

    public class KlineDto {
        public long Timestamp  { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal Turnover { get; set; }
    }
}