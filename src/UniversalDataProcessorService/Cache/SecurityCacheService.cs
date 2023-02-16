using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class SecurityCacheService : CachedDataService<Security>
    {
        protected IMemoryCache _cache;
        protected override Security DefaultEntity => new Security()
        {
            SecurityId = -1
        };
        public SecurityCacheService(ILogger<Security> _logger, IMemoryCache _cache) : base(_logger, _cache)
        {
           
        }

        protected override string CacheEntity => CacheKeys.Security;

        protected override string GenerateKey(Security entity) => $"{CacheEntity}_{entity.SecurityId}";

    }
}
