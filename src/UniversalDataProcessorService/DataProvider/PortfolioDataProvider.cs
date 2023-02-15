using UniversalDataProcessorModel;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService.DataProvider
{
    public class PortfolioDataProvider : StaticDataProvider<Portfolio>
    {
        public PortfolioDataProvider(IFileReader<Portfolio> fileReader, IConfiguration configuration) : base(configuration, fileReader)
        {
           
        }
        protected override string FileName => "portfolios.csv";
      
    }
}
