using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class AuthorRepository : INoSQLRepository<Author>
{

    public Author Post(Author entry)
    {
        throw new NotImplementedException();
    }

    public Author Get(string key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetAll()
    {
        throw new NotImplementedException();
    }

    public Author Put(Author entry)
    {
        throw new NotImplementedException();
    }

    public void Delete(string key)
    {
        throw new NotImplementedException();
    }
}
