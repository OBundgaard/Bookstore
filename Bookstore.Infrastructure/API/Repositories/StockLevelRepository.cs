using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class StockLevelRepository : INoSQLRepository<StockLevel>
{
    public StockLevel Post(StockLevel value)
    {
        throw new NotImplementedException();
    }

    public StockLevel Get(string key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<StockLevel> GetAll()
    {
        throw new NotImplementedException();
    }

    public StockLevel Put(StockLevel value)
    {
        throw new NotImplementedException();
    }

    public void Delete(string key)
    {
        throw new NotImplementedException();
    }
}
