using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Exceptions;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;
using System.Runtime.CompilerServices;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities;

public class OrderItemEntity
{

    public OrderItemEntity(int id, int quantity,  ProductEntity productEntity)
    {
        this.Id = id;

        this.Quantity = quantity > 0
            ? quantity 
            : throw new OrderItemInvalidStateException("Order quantity must be greater than zero");

        this.ProductEntity = productEntity ?? throw new OrderItemInvalidStateException("Product entity must be provided");
    }

    public int Id { get; }
    public int Quantity { get; }
    public ProductEntity ProductEntity { get; set; }
    public MoneyValueObject Price => this.ProductEntity.Price;
    public MoneyValueObject LineAmount => new MoneyValueObject(amount: this.Quantity * this.Price.Amount, currency: this.Price.Currency);
}
