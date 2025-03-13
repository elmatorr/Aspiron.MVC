using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Contracts
{
    // Cache interface
    public interface ICacheProvider
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? expiry = null);
        void Remove(string key);
        Task ClearAllCacheAsync();
        T GetOrCreate<T>(string key, Func<T> createItem, TimeSpan? expiry = null);
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> createItem, TimeSpan? expiry = null);
    }
}
