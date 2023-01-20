using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Dtos;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities;

public class OrderEntity
{
    public OrderEntity(int orderId, OrderEntityStatus status)
    {
        this.Id = orderId;
        this.Status = status;
    }
    public int Id { get;  }
    public OrderEntityStatus Status { get; private set; }

    internal void UpdateOrderStatus(UpdateOrderStatusDto dto)
    {
        if (dto == null) throw new ArgumentException(nameof(dto));
        if (dto.Id <= 0) throw new ArgumentException(nameof(dto.Id));

        var fromStatus = this.Status;
        var toStatus = (OrderEntityStatus)dto.StatusId;

        switch (toStatus)
        {
            case OrderEntityStatus.Received:
                this.ReceiveOrder(dto);
                break;
            case OrderEntityStatus.Processing:
                this.ProcessOrder(dto);
                break;
            case OrderEntityStatus.Shipped:
                this.ShipOrder(dto);
                break;
            case OrderEntityStatus.Delivered:
                this.DeliverOrder(dto);
                break;
            default:
                throw new NotImplementedException("Unknown order status. Unable to update");
        }
        this.Status = toStatus;
    }

    private void ReceiveOrder(UpdateOrderStatusDto dto)
    {
        if (this.Status != OrderEntityStatus.None)
            throw new ArgumentException("Unable to receive order, current state of the order must be 'None'.");
    }

    private void ProcessOrder(UpdateOrderStatusDto dto)
    {
        if (this.Status != OrderEntityStatus.Received)
            throw new ArgumentException("Unable to process order, current state of the order must be 'Received'.");
    }

    private void ShipOrder(UpdateOrderStatusDto dto)
    {
        if (this.Status != OrderEntityStatus.Processing)
            throw new ArgumentException("Unable to ship order, current state of the order must be 'Processing'.");
    }
    private void DeliverOrder(UpdateOrderStatusDto dto)
    {
        if (this.Status != OrderEntityStatus.Shipped)
            throw new ArgumentException("Unable to deliver order, current state of the order must be 'Shipped'.");
    }


}

public enum OrderEntityStatus
{
    None = 0,
    Received = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4,
}