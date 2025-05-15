using System.Globalization;
using MyProject.Domain.BybitModels.Prices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ByBit.ModelConverter;

public class KlineListConverter : JsonConverter<List<Kline>>
{
    public override List<Kline> ReadJson(JsonReader reader, Type objectType, List<Kline>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var result = new List<Kline>();
        var array = JArray.Load(reader);

        foreach (var item in array)
        {
            if (item is JArray values && values.Count == 7)
            {
                result.Add(new Kline
                {
                    StartTime = long.Parse(values[0]!.ToString()),
                    Open = decimal.Parse(values[1]!.ToString(), CultureInfo.InvariantCulture),
                    High = decimal.Parse(values[2]!.ToString(), CultureInfo.InvariantCulture),
                    Low = decimal.Parse(values[3]!.ToString(), CultureInfo.InvariantCulture),
                    Close = decimal.Parse(values[4]!.ToString(), CultureInfo.InvariantCulture),
                    Volume = decimal.Parse(values[5]!.ToString(), CultureInfo.InvariantCulture),
                    Turnover = decimal.Parse(values[6]!.ToString(), CultureInfo.InvariantCulture),
                });
            }
        }

        return result;
    }

    public override void WriteJson(JsonWriter writer, List<Kline>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
