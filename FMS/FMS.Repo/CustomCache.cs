using Microsoft.Extensions.Caching.Memory;

namespace FMS.Repo
{
    public interface ICustomCache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal);
        IDictionary<string, object> GetAllCaches();
        void Remove(string key);
        void Clear();
    }
    public class CustomCache : ICustomCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly HashSet<string> _keys = new HashSet<string>();
        public CustomCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T Get<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T value);
            return value;
        }
        public void Set<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            var _options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime,
                SlidingExpiration = slidingExpiration,
                Priority = priority
            };
            _memoryCache.Set(key, value, _options);
            _keys.Add(key);
        }
        public IDictionary<string, object> GetAllCaches()
        {
            var allItems = new Dictionary<string, object>();
            foreach (var key in _keys.ToList()) 
            {
                if (_memoryCache.TryGetValue(key, out object value))
                {
                    allItems[key] = value;
                }
                else
                {
                    _keys.Remove(key);
                }
            }
            return allItems;
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            _keys.Remove(key);
        }
        public void Clear()
        {
            if (_memoryCache is MemoryCache concreteMemoryCache)
            {
                concreteMemoryCache.Clear();
            }
            _keys.Clear();
        }
    }
}
