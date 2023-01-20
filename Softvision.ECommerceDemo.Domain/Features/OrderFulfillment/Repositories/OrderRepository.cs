namespace Softvision.ECommerceDemo.Core.Features.OrderFulfillment.Repositories;

using Softvision.ECommerceDemo.Core.Features.OrderFulfillment.EFModels;

public interface IOrderRepository
{
    OrderEfModel? GetOrder(int id);
}

public class OrderRepository : IOrderRepository
{
    private readonly FakeDbContext _fakeDbContext;
    public OrderRepository()
    {
        _fakeDbContext = new FakeDbContext();
    }

    public OrderEfModel? GetOrder(int id)
    {
        // For Demo purposes data is hard coded, in real APIs this will come from a database
        return _fakeDbContext?.Orders?.FirstOrDefault(x => x.Id == id);
    }
}
