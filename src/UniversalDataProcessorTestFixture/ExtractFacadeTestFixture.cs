using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorService.Extract;

namespace UniversalDataProcessorTestFixture
{
    [TestFixture]
    public class ExtractFacadeTestFixture:TestBase
    {
        [Test]
        public void Generates_File_Correctly()
        {
            var filePath = "..\\..\\..\\TestFile\\transactions.csv";
            var extractFacade = serviceProvider.GetService<IExtractFactory>();
            extractFacade.GenerateExtract(filePath);

        }
    }
}
