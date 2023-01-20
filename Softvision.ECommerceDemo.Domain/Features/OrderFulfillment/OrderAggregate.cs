using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Dtos;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Exceptions;
using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment
{
    public class OrderAggregate
    {
        public OrderAggregate(OrderEntity order, IEnumerable<OrderItemEntity> orderItems, CustomerEntity customerEntity)
        {
            this.Order = order ?? throw new OrderInvalidStateException("Order entity cannot be null, exist it must!");

            this.Customer = customerEntity ?? throw new OrderInvalidStateException("Order cannot exist without customer");

            this.OrderItems = orderItems != null && orderItems.Any()
                ? orderItems.ToList()
                : throw new OrderInvalidStateException("Order must have at least one line item.");
        }

        // Aggregate root
        public OrderEntity Order { get; set; }
        public CustomerEntity Customer { get; }
        public List<OrderItemEntity> OrderItems { get; }

        public bool EligibleForFreeShipping 
        { 
            get { return this.OrderItems.Sum(x => x.LineAmount.Amount) >= 1000; } 
        }

        public int TotalItems => this.OrderItems.Count;

        public void UpdateOrderStatus(UpdateOrderStatusDto dto)
        {
            this.Order?.UpdateOrderStatus(dto);
        }


    }
}
