using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;
using UniversalDataProcessorService.DataProvider;

namespace UniversalDataProcessorService.Cache
{
    public class CacheFacade: ICacheFacade
    {
        private ICachedDataService<Security> cachedSecurityDataService;
        private ICachedDataService<Portfolio> cachedPortfolioDataService;
        private IStaticDataProvider<Security> securityDataProvider;
        private IStaticDataProvider<Portfolio> portfolioDataProvider;
        public CacheFacade(ICachedDataService<Security> cachedSecurityDataService, ICachedDataService<Portfolio> cachedPortfolioDataService, IStaticDataProvider<Security> securityDataProvider, IStaticDataProvider<Portfolio> portfolioDataProvider)
        {
            this.cachedPortfolioDataService = cachedPortfolioDataService;
            this.cachedSecurityDataService = cachedSecurityDataService;
            this.securityDataProvider = securityDataProvider;
            this.portfolioDataProvider = portfolioDataProvider;
        }

        public void InitializeCache()
        {
            cachedPortfolioDataService.AddItemToCache(portfolioDataProvider.GetFileData());
            cachedSecurityDataService.AddItemToCache(securityDataProvider.GetFileData());
        }
       
    }
    public interface ICacheFacade
    {
        void InitializeCache();
    }
}
