using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class CachedOrderRepository : IRelationalRepository<Order>
{
    private readonly OrderRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedOrderRepository(OrderRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;

    }

    public async Task Delete(int id)
    {
        await _decorated.Delete(id);
    }

    public async Task<Order> Get(int id)
    {
        string key = $"Order_{id}";

        return await _memoryCache.GetOrCreateAsync(
            key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.Get(id);
            });
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _decorated.GetAll();
    }

    public async Task<Order> Post(Order entry)
    {
        return await _decorated.Post(entry);
    }

    public async Task<Order> Put(Order entry)
    {
        return await _decorated.Put(entry);
    }
}
