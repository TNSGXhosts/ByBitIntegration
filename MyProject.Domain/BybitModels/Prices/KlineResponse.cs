using ByBit.ModelConverter;
using MyProject.Domain.BybitModels.Prices;
using Newtonsoft.Json;

namespace BybitModels;

public class KlineResponse
{
    [JsonProperty("retCode")]
    public int RetCode { get; set; }

    [JsonProperty("retMsg")]
    public string RetMsg { get; set; } = null!;

    [JsonProperty("result")]
    public KlineList Result { get; set; } = null!;
}

public class KlineList {
    [JsonProperty("list")]
    [JsonConverter(typeof(KlineListConverter))]
    public required List<Kline> Klines { get; set; }
}