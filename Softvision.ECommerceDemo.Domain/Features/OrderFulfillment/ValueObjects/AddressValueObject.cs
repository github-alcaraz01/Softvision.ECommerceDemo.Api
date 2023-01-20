namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

public class AddressValueObject : ValueObjectBase
{
    public AddressValueObject(string street, string city, string province)
    {
        Street = street;
        City = city;
        Province = province;
    }

    public string Street { get; }
    public string City { get; }
    public string Province { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        return new List<object> 
        { 
            this.Street,
            this.City,
            this.Province 
        };
    }
}
