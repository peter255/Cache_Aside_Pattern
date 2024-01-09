using Cache_Aside_Pattern.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace Cache_Aside_Pattern.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrSet<T>(string key, Func<T> getItemCallback, TimeSpan cacheDuration)
        {
            var cacheEntry = _memoryCache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = cacheDuration;
                return getItemCallback();
            });

            return (T)cacheEntry;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}

