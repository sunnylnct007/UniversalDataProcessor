using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversalDataProcessorModel;
using UniversalDataProcessorService.DataProvider;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorTestFixture
{
    [TestFixture]
    public class SecurityDataProviderTestFixture:TestBase
    {
        private IStaticDataProvider<Security> dataProvider;
        [SetUp]
        public void Setup()
        {
            dataProvider = serviceProvider.GetService<IStaticDataProvider<Security>>();
        }

        [Test]
        public void Can_Read_SecurityData()
        {
            var data = dataProvider.GetFileData();
            Assert.That(2, Is.EqualTo(data.Count));
        }
    }
    
}