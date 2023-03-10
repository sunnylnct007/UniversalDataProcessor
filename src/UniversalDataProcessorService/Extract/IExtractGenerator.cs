using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.Extract
{
    public  interface IExtractGenerator<T>
    {
        Task GenerateExtract(IList<T> lstItems,ExtractConfig config);
    }
}
