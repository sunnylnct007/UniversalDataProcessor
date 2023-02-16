using UniversalDataProcessorModel;

namespace UniversalDataProcessorDataFramework
{
    public class UniversalDataProcessorDbContext : DbContext
    {
        public UniversalDataProcessorDbContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<ExtractConfig> ExtractConfigs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExtractConfig).Assembly);
        }
    }
}