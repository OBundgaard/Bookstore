

namespace Bookstore.Core.Interfaces;

public interface IRelationalRepository<T>
{
    T Post(T entry);
    T Get(int id);
    IEnumerable<T> GetAll();
    T Put(T entry);
    void Delete(int id);
}
