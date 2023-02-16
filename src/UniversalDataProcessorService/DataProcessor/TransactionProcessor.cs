using AutoMapper;
using UniversalDataProcessorModel;
using UniversalDataProcessorModel.Decorator;
using UniversalDataProcessorService.Cache;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService.DataProcessor
{
    public class TransactionProcessor<Transaction> : ISourceProcessor<Transaction>
    {
        private IFileReader<Transaction> transactionFileReader;
       private IMapper mapper;

        public TransactionProcessor(IFileReader<Transaction> transactionFileReader, IMapper mapper)
        {
            this.transactionFileReader = transactionFileReader;
            this.mapper = mapper;
        }
        public IList<TransactionDecorator> ProcessTransaction(string filePath)
        {
            var transactions = transactionFileReader.ReadFile(File.OpenRead(filePath));
            var lsttransactions = mapper.Map<IList<Transaction>, IList<TransactionDecorator>>(transactions);
           
             return lsttransactions;
        }
    }
}
