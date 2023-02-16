using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataProcessorService.Extract
{
    public interface IExtractFacade
    {
        void GenerateExtract(string filePath);
    }
}
