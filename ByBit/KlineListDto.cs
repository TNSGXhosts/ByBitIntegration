using Newtonsoft.Json;

namespace Axi.Bybit {
    public class KlineListDto {
        [JsonProperty("list")]
        public List<KlineDto> Klines { get; set; }
    }

    public class KlineDto {
        public long Timestamp  { get; set; }
        public decimal Open       { get; set; }
        public decimal Close { get; set; }
        public decimal Low       { get; set; }
        public decimal Cllose     { get; set; }
        public long Volume        { get; set; }
        public decimal TotalVolume { get; set; }
    }
}