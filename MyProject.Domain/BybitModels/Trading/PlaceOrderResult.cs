namespace MyProject.Domain.BybitModels.Trading;

public class PlaceOrderResult
{
    public required string OrderId  { get; set; } = string.Empty;
    public required string OrderLinkId { get; set; } = string.Empty;
}