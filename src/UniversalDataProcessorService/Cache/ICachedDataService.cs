using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;


namespace UniversalDataProcessorService.Cache
{
    public interface ICachedDataService<T> where T : class
    {
        void AddItemToCache(IList<T> items);
        T FindByKey(string key);
    }
    public abstract class CachedDataService<T> : ICachedDataService<T> where T : class
    {
        protected IMemoryCache _cache;
        protected volatile bool initialized = false;
        protected readonly object _lock = new object();
        protected virtual T DefaultEntity => default;
        protected ConcurrentDictionary<string, T> cache = new ConcurrentDictionary<string, T>();

        protected ILogger<T> logger;
        protected abstract string CacheEntity { get; }
        public CachedDataService(ILogger<T> logger, IMemoryCache cache)
        {
            this.logger = logger;
            _cache = cache;
        }
        public T FindByKey(string key)
        {
            _cache.TryGetValue($"{CacheEntity}_{key}", out T result);          
           
            return result?? DefaultEntity;

        }      
           
        protected abstract string GenerateKey(T entity);

        public void AddItemToCache(IList<T> items)
        {
            foreach (var item in items)
            {
                var key = GenerateKey(item);
                if (!_cache.TryGetValue(key, out T cachedItem))
                {
                    _cache.Set(key, item);

                }
                else
                {
                    //Log business exception
                    logger.LogWarning($"Duplicate PortfolioId found {key}. Taking the first one only");
                }
            }


        }

   
    }
}
