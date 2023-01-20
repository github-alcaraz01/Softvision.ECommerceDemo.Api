using Softvision.ECommerceDemo.Core.Features.OrderFulfillment;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Dtos;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Repositories;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

namespace Softvision.ECommerceDemo.Api.Services;

public interface IOrderService
{
    Task UpdateOrderStatus(UpdateOrderStatusDto dto);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task UpdateOrderStatus(UpdateOrderStatusDto dto)
    {
        var orderEfModel = _orderRepository.GetOrder(dto.Id);
        var orderEntity = new OrderEntity(dto.Id, (OrderEntityStatus)dto.StatusId);

        var orderItemsEntity = orderEfModel.OrderItems
            .Select(x => 
            {
                if (x.Product == null)
                    throw new ArgumentException("Product is required when creating an Order Item.");
                return new OrderItemEntity(
                    id: x.Id,
                    quantity: x.Quantity,
                    productEntity: new ProductEntity(x.Product.Id, x.Product.Description, x.Product.StockOnHand, x.Product.Price, x.Product.PriceCurrency)
                );
            });
        

        var customerEntity = new CustomerEntity(
            id: orderEfModel.Customer.Id,
            firstName: orderEfModel.Customer.FirstName,
            lastName: orderEfModel.Customer.LastName,
            address: new AddressValueObject(
                street: orderEfModel.Customer.StreetAddress,
                city: orderEfModel.Customer.CityAddress,
                province: orderEfModel.Customer.ProvinceAddress)
        );
        

        var orderAggregate = new OrderAggregate(orderEntity, orderItemsEntity, customerEntity);
        orderAggregate.UpdateOrderStatus(dto);
        return Task.FromResult(1);
    }
}