using UniversalDataProcessorModel.Decorator;
using AutoMapper;
using UniversalDataProcessorModel.Dto;

namespace UniversalDataProcessorService.AutoMap
{
    public class TransactionDecoratorToOmsTypeCCC : Profile
    {
        public TransactionDecoratorToOmsTypeCCC()
        {
            CreateMap<TransactionDecorator, OmsTypeCCC>()
                .ForMember(destination => destination.Ticker, map => map.MapFrom(source => source.Security.Ticker))
                .ForMember(destination => destination.PortfolioCode, map => map.MapFrom(source => source.Portfolio.PortfolioCode));
        }
        private string GetBuySellFlag(string buysell)
        {
            if(buysell.Equals("BUY", StringComparison.OrdinalIgnoreCase))
            {
                return "B";
            }
            return "S";
        }
    }
}

