using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataProcessorService.Extract
{
    public interface IExtractFactory
    {
        void GenerateExtract(string filePath);
    }
}
