using StackExchange.Redis;

namespace API.Contexts;

public class NoSQLDbContext : IDisposable
{
    private readonly ConnectionMultiplexer _connection;
    public IDatabase Database { get; }

    public NoSQLDbContext(string connectionString)
    {
        _connection = ConnectionMultiplexer.Connect(connectionString);
        Database = _connection.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var serializedValue = System.Text.Json.JsonSerializer.Serialize(value);
        await Database.StringSetAsync(key, serializedValue, expiry);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await Database.StringGetAsync(key);
        return value.HasValue
            ? System.Text.Json.JsonSerializer.Deserialize<T>(json: value)
            : default;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string prefix)
    {
        var server = _connection.GetServer(_connection.GetEndPoints().First());
        var keys = server.Keys(pattern: $"{prefix}:*").ToArray();

        if (!keys.Any())
            return Enumerable.Empty<T>();

        var tasks = keys.Select(key => GetAsync<T>(key.ToString()));
        return await Task.WhenAll(tasks);
    }


    public async Task<bool> DeleteAsync(string key)
    {
        return await Database.KeyDeleteAsync(key);
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
