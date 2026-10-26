using StackExchange.Redis;

// Redis sample: cache-aside pattern with a TTL, JSON payload.
public class CacheService
{
    private readonly IDatabase _db;
    public CacheService(IConnectionMultiplexer mux) => _db = mux.GetDatabase();
    public async Task<string?> GetAsync(string key) => await _db.StringGetAsync(key);
    public Task SetAsync(string key, string value) => _db.StringSetAsync(key, value, TimeSpan.FromMinutes(5));
}
