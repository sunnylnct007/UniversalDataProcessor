using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorService.Cache;
using UniversalDataProcessorService.Extract;

namespace UniversalDataProcessorTestFixture
{
    [TestFixture]
    public class ExtractFactoryTestFixture:TestBase
    {
        [Test]
        public void Generates_File_Correctly()
        {
            var filePath = "..\\..\\..\\TestFile\\transactions.csv";
            var cachefacade= serviceProvider.GetService<ICacheFacade>();
            cachefacade.InitializeCache();
            var extractFacade = serviceProvider.GetService<IExtractFactory>();
            Assert.DoesNotThrow(() =>
            {
                extractFacade.GenerateExtract(filePath);
            });

        }
    }
}
