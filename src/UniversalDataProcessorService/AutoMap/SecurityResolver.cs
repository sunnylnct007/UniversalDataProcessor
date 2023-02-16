using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using UniversalDataProcessorService.Cache;

namespace UniversalDataProcessorService.AutoMap
{
    public class SecurityResolver : IValueResolver<Transaction, TransactionDecorator, Security>
    {
        private ICachedDataService<Security> cachedService;
        public SecurityResolver(ICachedDataService<Security> cachedService)
        {
            this.cachedService = cachedService;
        }
        public Security Resolve(Transaction source, TransactionDecorator destination, Security member, ResolutionContext context)
        {
            return cachedService.FindByKey(source.SecurityId.ToString());
        }
    }
}
