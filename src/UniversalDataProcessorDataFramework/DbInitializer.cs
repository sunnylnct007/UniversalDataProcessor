using UniversalDataProcessorModel;

namespace UniversalDataProcessorDataFramework
{
    internal class DbInitializer
    {
        internal static void Initialize(UniversalDataProcessorDbContext context)
        {
            if (context.ExtractConfigs.Any())
            {
                return;
            }

            var lstConfigs = new List<ExtractConfig>();

            lstConfigs.Add(new ExtractConfig()
            {
                Name = "OmsTypeAAA",
                Extension = "aaa",
                Delimeter = ",",
                ShowHeader = true,
            });

            lstConfigs.Add(new ExtractConfig()
            {
                Name = "OmsTypeBBB",
                Extension = "bbb",
                Delimeter = "|",
                ShowHeader = true,
            });

            lstConfigs.Add(new ExtractConfig()
            {
                Name = "OmsTypeCCC",
                Extension = "ccc",
                Delimeter = ",",
                ShowHeader = false,
            });

            context.ExtractConfigs.AddRange(lstConfigs);
            context.SaveChanges();
        }
    }
}