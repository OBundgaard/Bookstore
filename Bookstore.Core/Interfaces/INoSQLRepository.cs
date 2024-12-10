

namespace Bookstore.Core.Interfaces;

public interface INoSQLRepository<T>
{
    Task<T> Post(T entry);
    Task<T> Get(string key);
    Task<IEnumerable<T>> GetAll();
    Task<T> Put(T entry);
    Task Delete(string key);
}
