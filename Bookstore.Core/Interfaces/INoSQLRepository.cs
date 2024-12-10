

namespace Bookstore.Core.Interfaces;

public interface INoSQLRepository<T>
{
    Task Post(T entry);
    Task Get(string key);
    Task<IEnumerable<T>> GetAll();
    Task Put(T entry);
    Task Delete(string key);
}
