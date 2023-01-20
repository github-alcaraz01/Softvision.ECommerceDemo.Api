using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Repositories
{
    public class FakeDbContext
    {
        private IEnumerable<OrderEfModel> orders;

        public FakeDbContext()
        {
        }
        public ICollection<OrderEfModel> Orders { 
            get 
            {
                return new List<OrderEfModel> 
                {
                    new OrderEfModel
                    {
                        Id = 1,
                        CustomerId = 10,
                        DateOrdered = new DateTime(2022, 12, 26),
                        OrderItems = new List<OrderItemEfModel>
                        {
                            new OrderItemEfModel { Id = 1020, ProductId = 4020, Quantity = 2, DiscountAmount = 500, Product = new ProductEfModel { Id = 4020, Description = "Mountain Bike", Price = 20_000, PriceCurrency = "PHP", DeliveryLeadTimeInDays = 3 } },
                            new OrderItemEfModel { Id = 1030, ProductId = 4030, Quantity = 2, DiscountAmount = 0, Product = new ProductEfModel { Id = 4030, Description = "Baby Shark Toy", Price = 500, PriceCurrency = "PHP", DeliveryLeadTimeInDays = 15  } }
                        },
                        StatusId = 2,
                        Customer = new CustomerEfModel
                        {
                            Id = 170,
                            FirstName = "George",
                            LastName = "Harisson",
                            StreetAddress = "5F Insular Life Building, Ayala Avenue",
                            CityAddress = "Makati",
                            ProvinceAddress = "NCR"
                        }
                    },
                    new OrderEfModel
                    {
                        Id = 2,
                        CustomerId = 10,
                        DateOrdered = new DateTime(2023, 01, 15),
                        OrderItems = new List<OrderItemEfModel>
                        {
                            new OrderItemEfModel { Id = 2020, ProductId = 4050, Quantity = 2, DiscountAmount = 0, Product = new ProductEfModel { Id = 4020, Description = "USB Headphone", Price = 1_300, PriceCurrency = "PHP", DeliveryLeadTimeInDays = 5 } },
                            new OrderItemEfModel { Id = 2030, ProductId = 4060, Quantity = 2, DiscountAmount = 0, Product = new ProductEfModel { Id = 4060, Description = "Mouse", Price = 750, PriceCurrency = "PHP", DeliveryLeadTimeInDays = 2  } }
                        },
                        StatusId = 2,
                        Customer = new CustomerEfModel
                        {
                            Id = 180,
                            FirstName = "Ringo",
                            LastName = "Starr",
                            StreetAddress = "5F Three Towers, Oritigas Ave.",
                            CityAddress = "Pasig",
                            ProvinceAddress = "NCR"
                        }
                    }
                };
            } 
        }
    }
}
