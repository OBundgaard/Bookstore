using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class CustomerRepository : IRelationalRepository<Customer>
{
    public Customer Post(Customer entry)
    {
        throw new NotImplementedException();
    }

    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer Put(Customer entry)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
