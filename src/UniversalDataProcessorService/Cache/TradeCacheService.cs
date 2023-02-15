using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class SecurityCacheService : CachedDataService<Security>
    {
       
        public SecurityCacheService(ILogger<Security> _logger) : base(_logger)
        {
           
        }
       
        protected override string GenerateKey(Security entity) => entity.SecurityId.ToString();

    }
    public class PortfolioCacheService : CachedDataService<Portfolio>
    {
        public PortfolioCacheService(ILogger<Portfolio> _logger) : base(_logger)
        {
          
        }
       

        protected override string GenerateKey(Portfolio entity) => $"{CacheKeys.Portfolio}_{entity.PortfolioId}";

    }
}
