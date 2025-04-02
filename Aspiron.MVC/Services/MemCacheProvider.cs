using Aspiron.MVC.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace Aspiron.MVC.Services
{
    // MemCacheProvider implementation using MemoryCache
    public class MemCacheProvider : ICacheProvider
    {
        private MemoryCache _memoryCache;

        public MemCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = (MemoryCache)memoryCache;
        }

        public T? Get<T>(string key)
        {
            return _memoryCache.TryGetValue(key, out T? value) ? value : default(T);
        }

        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            if (expiry.HasValue)
            {
                _memoryCache.Set(key, value, expiry.Value);
            }
            else
            {
                _memoryCache.Set(key, value);
            }
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public async Task ClearAllCacheAsync()
        {
            await Task.Run(() =>
            {
                _memoryCache.Dispose();
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            });
        }

        public T GetOrCreate<T>(string key, Func<T> createItem, TimeSpan? expiry = null)
        {
            var cacheEntry = _memoryCache.GetOrCreate(key, entry =>
            {
                if (expiry.HasValue)
                {
                    entry.SetAbsoluteExpiration(expiry.Value);
                }

                return createItem();
            });

            return (T)cacheEntry;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> createItem, TimeSpan? expiry = null)
        {
            var cacheEntry = await _memoryCache.GetOrCreateAsync(key, async entry =>
            {
                if (expiry.HasValue)
                {
                    entry.SetAbsoluteExpiration(expiry.Value);
                }

                return await createItem();
            });

            return (T)cacheEntry;
        }
    }

}
