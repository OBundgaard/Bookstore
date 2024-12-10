using API.Contexts;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using System.Runtime.InteropServices;

namespace API.Repositories;

public class StockLevelRepository : INoSQLRepository<StockLevel>
{
    private readonly NoSQLDbContext _context;
    private readonly string _collectionKey;

    public StockLevelRepository(NoSQLDbContext context, string collectionKey)
    {
        _context = context;
        _collectionKey = collectionKey;
    }

    public async Task<StockLevel> Post(StockLevel entry)
    {
        await _context.SetAsync($"{_collectionKey}:{entry}", entry);
        return entry;
    }

    public async Task<StockLevel> Get(string key)
    {
        var stockLevels = await _context.GetAsync<StockLevel>($"{_collectionKey}:{key}");
        return stockLevels;
    }

    public async Task<IEnumerable<StockLevel>> GetAll()
    {
        var stockLevelCollection = await _context.GetAllAsync<StockLevel>(_collectionKey);
        return stockLevelCollection;
    }

    public async Task<StockLevel> Put(StockLevel entry)
    {
        await _context.SetAsync($"{_collectionKey}:{entry}", entry);
        return entry;
    }

    public async Task Delete(string key)
    {
        await _context.DeleteAsync($"{_collectionKey}:{key}");
    }
}
