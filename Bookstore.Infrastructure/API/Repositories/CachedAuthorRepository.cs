using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class CachedAuthorRepository : INoSQLRepository<Author>
{
    private readonly AuthorRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedAuthorRepository(AuthorRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;

    }

    public async Task Delete(string key)
    {
        await _decorated.Delete(key);
    }

    public async Task<Author> Get(string key)
    {
        string _key = $"Author_{key}";

        return await _memoryCache.GetOrCreateAsync(
            _key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.Get(key);
            });
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _decorated.GetAll();
    }

    public async Task<Author> Post(Author entry)
    {
        return await _decorated.Post(entry);
    }

    public async Task<Author> Put(Author entry)
    {
        return await _decorated.Put(entry);
    }
}
