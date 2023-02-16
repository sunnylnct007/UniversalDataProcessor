using Microsoft.Extensions.DependencyInjection;
using UniversalDataProcessorModel;
using UniversalDataProcessorService.DataProvider;

namespace UniversalDataProcessorTestFixture
{
    [TestFixture]
    public class PortfolioDataProviderTestFixture : TestBase
    {
        private IStaticDataProvider<Portfolio> dataProvider;
        [SetUp]
        public void Setup()
        {
            dataProvider = serviceProvider.GetService<IStaticDataProvider<Portfolio>>();
        }

        [Test]
        public void Can_Read_PortfolioData()
        {
            var data = dataProvider.GetFileData();
            Assert.That(2, Is.EqualTo(data.Count));
        }
    }
}