using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace API.Repositories;

public class CachedCustomerRepository : IRelationalRepository<Customer>
{
    private readonly CustomerRepository _decorated;
    private readonly IMemoryCache _memoryCache;

    public CachedCustomerRepository(CustomerRepository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;

    }

    public async Task Delete(int id)
    {
        await _decorated.Delete(id);
    }

    public async Task<Customer> Get(int id)
    {
        string key = $"Customer_{id}";

        return await _memoryCache.GetOrCreateAsync(
            key,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.Get(id);
            });
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _decorated.GetAll();
    }

    public async Task<Customer> Post(Customer entry)
    {
        return await _decorated.Post(entry);
    }

    public async Task<Customer> Put(Customer entry)
    {
        return await _decorated.Put(entry); ;
    }
}
