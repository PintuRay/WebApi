using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;

namespace FMS.Repo
{
    public interface IRedisCache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal);
        IDictionary<string, object> GetAllCaches();
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly ILogger<RedisCache> _logger;
        public RedisCache(IDistributedCache cache, IConnectionMultiplexer redisConnection, ILogger<RedisCache> logger)
        {
            _cache = cache;
            _logger = logger;
            _redisConnection = redisConnection;
        }
        public T Get<T>(string key)
        {
            try
            {
                var value = _cache.GetString(key);
                if (string.IsNullOrEmpty(value))
                { 
                    return default; 
                }
                else
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    return JsonSerializer.Deserialize<T>(value);
                }  
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving from cache");
                return default;
            }
        }
        public void Set<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            try
            {
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = absoluteExpireTime,
                    SlidingExpiration = slidingExpiration
                };

                var serializedValue = JsonSerializer.Serialize(value);
                _cache.SetString(key, serializedValue, options);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting cache");
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
        public IDictionary<string, object> GetAllCaches()
        {
            var result = new Dictionary<string, object>();
            try
            {
                var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());

                foreach (var key in server.Keys())
                {
                    var value = _cache.GetString(key);
                    if (!string.IsNullOrEmpty(value))
                    {
                        result[key.ToString()] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all caches");
            }
            return result;
        }
    } 
}
