namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

public class MoneyValueObject : ValueObjectBase
{
    public MoneyValueObject(decimal amount, string currency) 
    {
        this.Amount = amount;
        this.Currency = currency;
    }

    public decimal Amount { get; }
    public string Currency { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        return new List<object> { this.Amount, this.Currency };
    }
}
