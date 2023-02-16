using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using AutoMapper;

namespace UniversalDataProcessorService.AutoMap
{
    public class TransactionToTransactionDecoratorMap : Profile
    {
        public TransactionToTransactionDecoratorMap()
        {
            CreateMap<Transaction, TransactionDecorator>()
                .ForMember(destination => destination.Portfolio, map => map.MapFrom<PortfolioResolver>())
                .ForMember(destination => destination.Security, map => map.MapFrom<SecurityResolver>());

        }
    }
}
