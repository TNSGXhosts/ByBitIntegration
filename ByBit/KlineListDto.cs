using Newtonsoft.Json;

namespace Axi.Bybit
{
    public class KlineListDto
{
        [JsonProperty("list")]
        public required List<string> Klines { get;set; }
}
}
