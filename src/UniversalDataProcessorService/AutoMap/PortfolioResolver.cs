using AutoMapper;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using UniversalDataProcessorService.Cache;

namespace UniversalDataProcessorService.AutoMap
{
    public class PortfolioResolver : IValueResolver<Transaction, TransactionDecorator, Portfolio>
    {
        private ICachedDataService<Portfolio> cachedService;
        public PortfolioResolver(ICachedDataService<Portfolio> cachedService)
        {
            this.cachedService = cachedService;
        }
        public Portfolio Resolve(Transaction source, TransactionDecorator destination, Portfolio member, ResolutionContext context)
        {
            return cachedService.FindByKey(source.PortfolioId.ToString());
        }
    }
}
