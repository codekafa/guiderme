using Business.Service.Infrastructure;
using System;
using System.Runtime.Caching;

namespace Business.Service
{
    public class CacheService : ICacheService
    {
        protected ObjectCache Cache
        {
            get
            {
                return System.Runtime.Caching.MemoryCache.Default;
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Set(string key, object data, int cacheTimeM)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTimeM);
            Cache.Add(new CacheItem(key, data), policy);
        }
    }
}
