using Serilog;
using UniversalDataProcessorModel;
using ILogger = Serilog.ILogger;

namespace UniversalDataProcessorService.Cache
{
    public static class CacheInitializer
    {
        private static readonly ILogger _log = Log.ForContext(typeof(CacheInitializer));
        public static void RegisterCache(IServiceCollection services)
        {
            _log.Information("Started registering cache");
            services.AddSingleton<ICacheFacade, CacheFacade>();
            services.AddSingleton<ICachedDataService<Security>, SecurityCacheService>();
            services.AddSingleton<ICachedDataService<Portfolio>, PortfolioCacheService>();
            _log.Information("Completed  registering cache");
        }
    }
    public static class CacheKeys
    {
        public static string Security => "_Security";
        public static string Portfolio => "_Portfolio";
    }
}
