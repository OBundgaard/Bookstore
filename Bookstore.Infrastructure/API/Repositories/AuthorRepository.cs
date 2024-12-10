using API.Contexts;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;

namespace API.Repositories;

public class AuthorRepository : INoSQLRepository<Author>
{
    private readonly NoSQLDbContext db;

    public AuthorRepository(NoSQLDbContext context)
    {
        db = context;
    }

    public async Task<Author> Post(Author entry)
    {
        await db.SetAsync($"Authors:{entry.AuthorID.ToString()}", entry.AuthorName);
        return entry;
    }

    public async Task<Author> Get(string key)
    {
        var author = await db.GetAsync<Author>($"Authors:{key}");
        return author;
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        var authors = await db.GetAllAsync<Author>("Authors:");
        return authors;
    }

    public async Task<Author> Put(Author entry)
    {
        await db.SetAsync($"Authors:{entry.AuthorID.ToString()}", entry.AuthorName);
        return entry;
    }

    public async Task Delete(string key)
    {
        await db.DeleteAsync($"Authors:{key}");
    }
}
