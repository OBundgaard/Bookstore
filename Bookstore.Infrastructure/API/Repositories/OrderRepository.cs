using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class OrderRepository : IRelationalRepository<Order>
{
    public Order Post(Order entry)
    {
        throw new NotImplementedException();
    }

    public Order Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Order> GetAll()
    {
        throw new NotImplementedException();
    }

    public Order Put(Order entry)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
