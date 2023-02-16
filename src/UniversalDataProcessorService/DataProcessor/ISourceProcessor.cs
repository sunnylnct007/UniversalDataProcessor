using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel.Decorator;

namespace UniversalDataProcessorService.DataProcessor
{
    public interface ISourceProcessor<T>
    {
        IList<TransactionDecorator> ProcessTransaction(string filePath);
    }
}
