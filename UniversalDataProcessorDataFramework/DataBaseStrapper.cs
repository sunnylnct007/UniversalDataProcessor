

namespace UniversalDataProcessorDataFramework
{
    public static class DataBaseStrapper
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration, string dbConnection)
        {
            if (dbConnection == null)
            {
                var connectionStringBuilder =
                    new SqliteConnectionStringBuilder { DataSource = $"TradeAp;iService.db" };


                var connection = new SqliteConnection(connectionStringBuilder.ToString());

                services.AddDbContext<UniversalDataProcessorDbContext>(options =>
                {
                    options.UseSqlite(connection, o => o.MinBatchSize(1).MaxBatchSize(100)).LogTo(Console.WriteLine, LogLevel.Information);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                }, ServiceLifetime.Transient);
            }
            else
            {
                services.AddDbContext<UniversalDataProcessorDbContext>(options =>
                {


                    options.UseSqlServer(dbConnection, option =>
                    {
                        option.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        option.MinBatchSize(1).MaxBatchSize(100);
                        option.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        option.CommandTimeout(900);
                    }).LogTo(Console.WriteLine, LogLevel.Information)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


                }, ServiceLifetime.Transient);
            }

            using (var client = services.BuildServiceProvider().GetService<UniversalDataProcessorDbContext>())
            {

                client?.Database.EnsureCreated();

               // DbInitializer.Initialize(client);

            }
        }
    }
}