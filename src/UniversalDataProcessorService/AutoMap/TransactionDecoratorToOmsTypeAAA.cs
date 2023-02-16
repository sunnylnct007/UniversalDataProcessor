using UniversalDataProcessorModel.Decorator;
using AutoMapper;
using UniversalDataProcessorModel.Dto;
using AutoMapper.Configuration.Conventions;

namespace UniversalDataProcessorService.AutoMap
{
    public class TransactionDecoratorToOmsTypeAAA: Profile
    {
        public TransactionDecoratorToOmsTypeAAA()
        {
            CreateMap<TransactionDecorator, OmsTypeAAA>()
                .ForMember(destination => destination.ISIN, map=> map.MapFrom(source=>source.Security.ISIN))
                .ForMember(destination => destination.PortfolioCode, map => map.MapFrom(source => source.Portfolio.PortfolioCode));
        }
    }
}
