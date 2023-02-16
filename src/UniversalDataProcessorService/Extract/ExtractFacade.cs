using AutoMapper;
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
        private IMapper mapper;
        public ExtractFacade(ISourceProcessor<Transaction> transactionProcessor, IExtractGenerator<OmsTypeAAA> omstypeaaaExtractGenerator, IMapper mapper)
        {
            this.transactionProcessor = transactionProcessor;
            this.omstypeaaaExtractGenerator = omstypeaaaExtractGenerator;
            this.mapper = mapper;
        }

        public void GenerateExtract(string filePath)
        {
            var transactions = transactionProcessor.ProcessTransaction(filePath);
            var omsData = mapper.Map<IList<TransactionDecorator>, IList<OmsTypeAAA>>(transactions);
            omstypeaaaExtractGenerator.GenerateExtract(omsData, new ExtractConfig()
            {
                Name = "OmsTypeAAA",
                Delimeter = ","
            });
        }
    }
}
