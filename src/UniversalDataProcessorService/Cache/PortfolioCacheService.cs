using Microsoft.Extensions.Caching.Memory;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class PortfolioCacheService : CachedDataService<Portfolio>
    {
        protected override Portfolio DefaultEntity => new Portfolio()
        {
            PortfolioId = -1
        };
        public PortfolioCacheService(ILogger<Portfolio> _logger, IMemoryCache _cache) : base(_logger, _cache)
        {
          
        }

        protected override string CacheEntity => CacheKeys.Portfolio;

        protected override string GenerateKey(Portfolio entity) => $"{CacheEntity}_{entity.PortfolioId}";

    }
}
