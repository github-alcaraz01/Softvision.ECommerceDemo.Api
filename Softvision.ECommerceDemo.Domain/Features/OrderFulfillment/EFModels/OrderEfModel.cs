namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

public class OrderEfModel
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int CustomerId { get; set; }
    public DateTime DateOrdered { get; set; }
    public CustomerEfModel? Customer { get; set; }
    public IEnumerable<OrderItemEfModel>? OrderItems { get; set; }
}
