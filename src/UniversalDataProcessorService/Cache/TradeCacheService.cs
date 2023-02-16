using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class SecurityCacheService : CachedDataService<Security>
    {
        protected IMemoryCache _cache;
        public SecurityCacheService(ILogger<Security> _logger, IMemoryCache _cache) : base(_logger, _cache)
        {
           
        }
       
        protected override string GenerateKey(Security entity) => entity.SecurityId.ToString();

    }
    public class PortfolioCacheService : CachedDataService<Portfolio>
    {
        public PortfolioCacheService(ILogger<Portfolio> _logger, IMemoryCache _cache) : base(_logger, _cache)
        {
          
        }
       

        protected override string GenerateKey(Portfolio entity) => $"{CacheKeys.Portfolio}_{entity.PortfolioId}";

    }
}
