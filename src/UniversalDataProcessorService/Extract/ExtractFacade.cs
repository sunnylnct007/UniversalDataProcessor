using AutoMapper;
using UniversalDataProcessorDataFramework;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using UniversalDataProcessorModel.Dto;
using UniversalDataProcessorService.DataProcessor;

namespace UniversalDataProcessorService.Extract
{
    public class ExtractFactory : IExtractFactory
    {
        private ISourceProcessor<Transaction> transactionProcessor;
        private IExtractGenerator<OmsTypeAAA> omstypeaaaExtractGenerator;
        private IExtractGenerator<OmsTypeBBB> omstypebbbExtractGenerator;
        private IExtractGenerator<OmsTypeCCC> omstypecccExtractGenerator;
        private IMapper mapper;
        private UniversalDataProcessorDbContext dbContext;
        public ExtractFactory(ISourceProcessor<Transaction> transactionProcessor, IExtractGenerator<OmsTypeAAA> omstypeaaaExtractGenerator, IMapper mapper, IExtractGenerator<OmsTypeBBB> omstypebbbExtractGenerator, IExtractGenerator<OmsTypeCCC> omstypecccExtractGenerator, UniversalDataProcessorDbContext dbContext)
        {
            this.transactionProcessor = transactionProcessor;
            this.omstypeaaaExtractGenerator = omstypeaaaExtractGenerator;
            this.mapper = mapper;
            this.omstypebbbExtractGenerator = omstypebbbExtractGenerator;
            this.omstypecccExtractGenerator = omstypecccExtractGenerator;
            this.dbContext = dbContext;
        }

        public void GenerateExtract(string filePath)
        {
            var dictConfigs = dbContext.ExtractConfigs.ToDictionary(x => x.Name);
            var transactions = transactionProcessor.ProcessTransaction(filePath);
            var omsAAAData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeAAA>>(transactions);
            var omsBBBData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeBBB>>(transactions);
            var omsCCCData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeCCC>>(transactions);
            foreach (var extractconfig in dbContext.ExtractConfigs)
            {
                Generate(extractconfig, transactions);

            }

          
                      
        }
        private void Generate(ExtractConfig extractconfig, IList<TransactionDecorator> lstTransaction)
        {
            switch (extractconfig.Name)
            {
                case "OmsTypeAAA":
                    var omsAAAData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeAAA>>(lstTransaction);
                    omstypeaaaExtractGenerator.GenerateExtract(omsAAAData, extractconfig);
                    break;
                case "OmsTypeBBB":
                    var omsBBBData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeBBB>>(lstTransaction);
                    omstypebbbExtractGenerator.GenerateExtract(omsBBBData, extractconfig);
                    break;
                case "OmsTypeCCC":
                    var omsCCCData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeCCC>>(lstTransaction);
                    omstypecccExtractGenerator.GenerateExtract(omsCCCData, extractconfig);
                    break;
                default:
                    throw new NotSupportedException($"Undefined extract type {extractconfig.Name}");
            }
        }
    }
}
