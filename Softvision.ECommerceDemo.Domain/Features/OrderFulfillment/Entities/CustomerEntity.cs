using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Entities;

public class CustomerEntity
{
    public CustomerEntity(int id, string firstName, string lastName, AddressValueObject address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public AddressValueObject Address { get; }
}
