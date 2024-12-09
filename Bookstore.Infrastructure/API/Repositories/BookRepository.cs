using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class BookRepository : IRelationalRepository<Book>
{
    public Book Post(Book entry)
    {
        throw new NotImplementedException();
    }

    public Book Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public Book Put(Book entry)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
