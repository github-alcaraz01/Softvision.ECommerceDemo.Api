using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;
namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities
{
    public class ProductEntity
    {
        public ProductEntity(int id, string description, int stockOnHand, decimal price, string priceCurrency)
        {
            Id = id;
            Description = description;
            StockOnHand = stockOnHand;
            Price = new MoneyValueObject(price, priceCurrency);   
        }

        public int Id { get; }
        public string Description { get; }
        public int StockOnHand { get; }
        public MoneyValueObject Price { get;  }

    }
}
