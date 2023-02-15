using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Cache
{
    public class CacheFacade: ICacheFacade
    {
        private ICachedDataService<Security> cachedSecurityDataService;
        private ICachedDataService<Portfolio> cachedPortfolioDataService;
        public CacheFacade(ICachedDataService<Security> cachedSecurityDataService, ICachedDataService<Portfolio> cachedPortfolioDataService)
        {
            this.cachedPortfolioDataService = cachedPortfolioDataService;
            this.cachedSecurityDataService = cachedSecurityDataService;
        }

        public void InitializeCache()
        {
            cachedPortfolioDataService.AddItemToCache(null);
            cachedSecurityDataService.AddItemToCache(null);
        }
       
    }
    public interface ICacheFacade
    {
        void InitializeCache();
    }
}
