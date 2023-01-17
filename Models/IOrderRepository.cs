namespace SportsStore.Models;

public interface IOrderRepository
{
    IQueryable<Order> Orders { get; }

    public void SaveOrder(Order order);
}