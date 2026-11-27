using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using TiendaFunko.Shared.Configuration;

namespace TiendaFunko.Shared.Services.Cache;

public class RedisCacheService(IDistributedCache cache, IOptions<CacheOptions> options) : ICacheService
{
    private readonly CacheOptions _options = options.Value;
    private readonly SemaphoreSlim _factoryLock = new(1, 1);

    public async Task<T?> GetAsync<T>(string key, CancellationToken ct = default)
    {
        var data = await cache.GetStringAsync(key, ct);
        return data is null ? default : JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken ct = default)
    {
        var entryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? _options.DefaultExpiration,
            SlidingExpiration = _options.SlidingExpiration
        };
        await cache.SetStringAsync(key, JsonSerializer.Serialize(value), entryOptions, ct);
    }

    public async Task RemoveAsync(string key, CancellationToken ct = default)
    {
        await cache.RemoveAsync(key, ct);
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken ct = default)
    {
        var data = await cache.GetStringAsync(key, ct);
        return data is not null;
    }

    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null, CancellationToken ct = default)
    {
        var cached = await GetAsync<T>(key, ct);
        if (cached is not null) return cached;

        await _factoryLock.WaitAsync(ct);
        try
        {
            cached = await GetAsync<T>(key, ct);
            if (cached is not null) return cached;

            var value = await factory();
            if (value is not null)
                await SetAsync(key, value, expiration, ct);
            return value;
        }
        finally
        {
            _factoryLock.Release();
        }
    }
}