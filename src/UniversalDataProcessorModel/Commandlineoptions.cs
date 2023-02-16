using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
namespace UniversalDataProcessorModel
{
    public class ProcessorOptions
    {
        [Option('i', "InputFile", Required = false, HelpText = "Your input file")]
        public string InputTransactionFile { get; set; }

    }
}
