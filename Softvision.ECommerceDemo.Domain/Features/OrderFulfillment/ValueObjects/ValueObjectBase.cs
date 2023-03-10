namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.ValueObjects;

public abstract class ValueObjectBase
{
    protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
    {
        return !(EqualOperator(left, right));
    }

    // Subclass must implement this to pass the properties that determines equality
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObjectBase)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}
