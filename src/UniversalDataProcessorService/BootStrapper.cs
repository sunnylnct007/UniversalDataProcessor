using MediatR;
using Serilog;
using Serilog.Events;
using UniversalDataProcessorDataFramework;
using UniversalDataProcessorModel;
using UniversalDataProcessorService.Cache;
using UniversalDataProcessorService.DataProvider;
using UniversalDataProcessorService.Extract;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService
{
    public static class BootStrapper
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            services.AddSingleton(provider => configuration);

            var dbconnection = configuration.GetConnectionString("reconMauiConnection");

            ConfigureLogging();
            services.AddMemoryCache();
            services.AddMediatR(typeof(BootStrapper));
            services.AddTransient(typeof(IFileReader<>), typeof(FileReader<>));
            services.AddTransient(typeof(IExtractGenerator<>), typeof(ExtractGenerator<>));
            services.AddTransient(typeof(IFileGenerator<>), typeof(FileGenerator<>));
            services.AddScoped<IStaticDataProvider<Security>, SecurityDataProvider>();
            services.AddScoped<IStaticDataProvider<Portfolio>, PortfolioDataProvider>();
            DataBaseStrapper.RegisterDatabase(services, configuration, null);
            CacheInitializer.RegisterCache(services);
            services.AddLogging();
            var cachefacade = services.BuildServiceProvider().GetService<ICacheFacade>();
            cachefacade.InitializeCache();
        }
        //Currently only logging to file but can be changed to include DB logging as well
        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
       .Enrich.FromLogContext()
       .WriteTo.Console()
       .WriteTo.File(@".\UniversalDataProcessorlog.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        }
    }
}