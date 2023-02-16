using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel.Dto;
using UniversalDataProcessorService.Extract;

namespace UniversalDataProcessorTestFixture
{
    [TestFixture]
    public  class ExtractGeneratorTestFixture:TestBase
    {
        [Test]
        public async Task Is_Able_To_Generate_Extract()
        {
            var generator = serviceProvider.GetService<IExtractGenerator<OmsTypeAAA>>();
            Assert.DoesNotThrowAsync(async () =>
            {
                await generator.GenerateExtract(new List<OmsTypeAAA>()
                { new OmsTypeAAA(){ISIN="Test",Nominal=100m,PortfolioCode="Test",TransactionType="Test"
                }}
                , new UniversalDataProcessorModel.ExtractConfig()
                {
                    Name= "OmsTypeAAA.csv"
                });

            });
        }
    }
}
