using System.Collections.Concurrent;


namespace UniversalDataProcessorService.Cache
{
    public interface ICachedDataService<T> where T : class
    {
        Task InitilizeCache();
        Task<T?> FindByKey(string key);
    }
    public abstract class CachedDataService<T> : ICachedDataService<T> where T : class
    {
        protected virtual T DefaultEntity => default;
        protected ConcurrentDictionary<string, T> cache = new ConcurrentDictionary<string, T>();
       
       
        private IServiceProvider _serviceProvider;
        public CachedDataService(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
        }
        public async Task<T?> FindByKey(string key)
        {
            cache.TryGetValue(key, out T result);
           
           
            return result?? DefaultEntity;

        }      
           
        protected abstract string GenerateKey(T entity);

        public Task InitilizeCache()
        {
            throw new NotImplementedException();
        }
    }
}
