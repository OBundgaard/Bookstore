using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class CachedStockLevelRepository : INoSQLRepository<StockLevel>
{
    private readonly StockLevelRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedStockLevelRepository(StockLevelRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;

    }

    public async Task Delete(string key)
    {
        await _decorated.Delete(key);
    }

    public async Task<StockLevel> Get(string key)
    {
        string _key = $"StockLevel_{key}";

        return await _memoryCache.GetOrCreateAsync(
            _key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.Get(key);
            });
    }

    public async Task<IEnumerable<StockLevel>> GetAll()
    {
        return await _decorated.GetAll();
    }

    public async Task<StockLevel> Post(StockLevel entry)
    {
        return await _decorated.Post(entry);
    }

    public async Task<StockLevel> Put(StockLevel entry)
    {
        return await _decorated.Put(entry);
    }
}
