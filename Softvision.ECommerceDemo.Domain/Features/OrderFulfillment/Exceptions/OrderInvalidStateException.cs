namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Exceptions
{
    public class OrderInvalidStateException : Exception
    {
        public OrderInvalidStateException(string message) : base(message)
        {

        }
    }
}
