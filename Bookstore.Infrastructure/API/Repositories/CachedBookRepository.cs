using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class CachedBookRepository : IRelationalRepository<Book>
{
    private readonly BookRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedBookRepository(BookRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;

    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> Get(int id)
    {
        string key = $"Book_{id}";

        return await _memoryCache.GetOrCreateAsync(
            key, 
            async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
            return await _decorated.Get(id);
        });
    }

    public Task<IEnumerable<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Book> Post(Book entry)
    {
        return await _decorated.Post(entry);
    }

    public Task<Book> Put(Book entry)
    {
        throw new NotImplementedException();
    }
}
