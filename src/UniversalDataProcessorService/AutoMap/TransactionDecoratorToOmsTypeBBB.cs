using UniversalDataProcessorModel.Decorator;
using AutoMapper;
using UniversalDataProcessorModel.Dto;

namespace UniversalDataProcessorService.AutoMap
{
    public class TransactionDecoratorToOmsTypeBBB : Profile
    {
        public TransactionDecoratorToOmsTypeBBB()
        {
            CreateMap<TransactionDecorator, OmsTypeBBB>()
                .ForMember(destination => destination.Cusip, map => map.MapFrom(source => source.Security.CUSIP))
                .ForMember(destination => destination.PortfolioCode, map => map.MapFrom(source => source.Portfolio.PortfolioCode));
        }
    }
}

