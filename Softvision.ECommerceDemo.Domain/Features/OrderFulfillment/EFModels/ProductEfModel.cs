namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

public class ProductEfModel
{
    public int Id { get; set; }
    public int StockOnHand { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? PriceCurrency { get; set; }
    
    // The period between when an order is placed and when that order is delivered
    public int DeliveryLeadTimeInDays { get; set; }
}
