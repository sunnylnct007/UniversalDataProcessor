using AutoMapper;
using UniversalDataProcessorDataFramework;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using UniversalDataProcessorModel.Dto;
using UniversalDataProcessorService.DataProcessor;

namespace UniversalDataProcessorService.Extract
{
    public class ExtractFacade : IExtractFacade
    {
        private ISourceProcessor<Transaction> transactionProcessor;
        private IExtractGenerator<OmsTypeAAA> omstypeaaaExtractGenerator;
        private IExtractGenerator<OmsTypeBBB> omstypebbbExtractGenerator;
        private IExtractGenerator<OmsTypeCCC> omstypecccExtractGenerator;
        private IMapper mapper;
        private UniversalDataProcessorDbContext dbContext;
        public ExtractFacade(ISourceProcessor<Transaction> transactionProcessor, IExtractGenerator<OmsTypeAAA> omstypeaaaExtractGenerator, IMapper mapper, IExtractGenerator<OmsTypeBBB> omstypebbbExtractGenerator, IExtractGenerator<OmsTypeCCC> omstypecccExtractGenerator, UniversalDataProcessorDbContext dbContext)
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

            ExtractConfig config = null;
            if(dictConfigs.TryGetValue("OmsTypeAAA", out config))
            {
                omstypeaaaExtractGenerator.GenerateExtract(omsAAAData, config);
            }
            else
            {
                throw new InvalidDataException("Please ensure the configs have been defined for OmsTypeAAA");
            }
            if (dictConfigs.TryGetValue("OmsTypeBBB", out config))
            {
                omstypebbbExtractGenerator.GenerateExtract(omsBBBData, config);
            }
            else
            {
                throw new InvalidDataException("Please ensure the configs have been defined for OmsTypeBBB");
            }

            if (dictConfigs.TryGetValue("OmsTypeCCC", out config))
            {
                omstypecccExtractGenerator.GenerateExtract(omsCCCData, config);
            }
            else
            {
                throw new InvalidDataException("Please ensure the configs have been defined for OmsTypeCCC");
            }
                      
        }
    }
}
