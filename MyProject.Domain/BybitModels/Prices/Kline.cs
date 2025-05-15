namespace MyProject.Domain.BybitModels.Prices;

public class Kline {
    public long StartTime  { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal Volume { get; set; }
    public decimal Turnover { get; set; }
}