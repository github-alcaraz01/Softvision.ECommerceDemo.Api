namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels
{
    public class CustomerEfModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? CityAddress { get; set; }
        public string? ProvinceAddress { get; set; }
    }
}
