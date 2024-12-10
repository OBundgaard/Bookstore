

namespace Bookstore.Core.Interfaces;

public interface IRelationalRepository<T>
{
    Task Post(T entry);
    Task Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task Put(T entry);
    Task Delete(int id);
}
