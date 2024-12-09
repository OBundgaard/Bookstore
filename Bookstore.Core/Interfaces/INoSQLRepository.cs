

namespace Bookstore.Core.Interfaces;

public interface INoSQLRepository<T>
{
    T Post(T entry);
    T Get(string key);
    IEnumerable<T> GetAll();
    T Put(T entry);
    void Delete(string key);
}
