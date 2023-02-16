using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversalDataProcessorService;

namespace UniversalDataProcessorTestFixture
{
    public class TestBase
    {
        protected IServiceProvider serviceProvider;
        protected IConfiguration configuration;
        [OneTimeSetUp]
        public void OneTimeTestBaseSetUp()
        {
            var servicecollection = new ServiceCollection();
            servicecollection.RegisterDependency();
            serviceProvider = servicecollection.BuildServiceProvider();
            configuration = serviceProvider.GetService<IConfiguration>();
        }
    }
}