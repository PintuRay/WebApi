using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;

namespace FMS.Repo
{
    public interface IRedisCache
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T> (string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal, CancellationToken cancellationToken = default);
        Task<IDictionary<string, string>> GetAllCachesAsync(CancellationToken cancellationToken = default);
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly ILogger<RedisCache> _logger;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public RedisCache(IDistributedCache cache, IConnectionMultiplexer redisConnection, ILogger<RedisCache> logger)
        {
            _cache = cache;
            _logger = logger;
            _redisConnection = redisConnection;
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var value = await _cache.GetStringAsync(key, cancellationToken);
                if (string.IsNullOrEmpty(value))
                    return default;
                return JsonSerializer.Deserialize<T>(value, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving from cache for key: {Key}", key);
                return default;
            }
        }
        public async Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null,TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal,CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            try
            {
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromHours(1),
                    SlidingExpiration = slidingExpiration
                };

                var serializedValue = JsonSerializer.Serialize(value, _jsonOptions);
                await _cache.SetStringAsync(key, serializedValue, options, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting cache for key: {Key}", key);
                throw;
            }
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
        public void RemoveByPrefix(string prefix)
        {
            try
            {
                var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
                var keys = server.Keys(pattern: $"{prefix}*");
                foreach (var key in keys)
                {
                    _cache.Remove(key.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing cache by prefix");
            }
        }
        public void Clear()
        {
            try
            {
                var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
                server.FlushDatabase();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing cache");
            }
        }
        public async Task<IDictionary<string, string>> GetAllCachesAsync(CancellationToken cancellationToken = default)
        {
            var result = new Dictionary<string, string>();
            try
            {
                var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
                var keys = server.Keys();

                foreach (var key in keys)
                {
                    var value = await _cache.GetStringAsync(key, cancellationToken);
                    if (!string.IsNullOrEmpty(value))
                    {
                        result[key.ToString()] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all caches");
                // Consider whether to throw
            }
            return result;
        }
    } 
}
