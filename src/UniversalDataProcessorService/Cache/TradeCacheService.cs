using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class SecurityCacheService : CachedDataService<Security>
    {
        private IServiceProvider _serviceProvider;
        public SecurityCacheService(IServiceProvider _serviceProvider) : base(_serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
        }
       
        protected override string GenerateKey(Security entity) => entity.SecurityId.ToString();

    }
    public class PortfolioCacheService : CachedDataService<Portfolio>
    {
        private IServiceProvider _serviceProvider;
        public PortfolioCacheService(IServiceProvider _serviceProvider) : base(_serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
        }
       

       
        protected override string GenerateKey(Portfolio entity) => entity.PortfolioId.ToString();

    }
}
