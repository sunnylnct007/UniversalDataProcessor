using Microsoft.EntityFrameworkCore;

namespace UniversalDataProcessorDataFramework
{
    public class UniversalDataProcessorDbContext : DbContext
    {
        public UniversalDataProcessorDbContext(DbContextOptions options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(Trade).Assembly);
        }
    }
}