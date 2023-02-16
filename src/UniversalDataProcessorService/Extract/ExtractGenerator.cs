using UniversalDataProcessorModel;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService.Extract
{
    public class ExtractGenerator<T> : IExtractGenerator<T>
    {
        private IFileGenerator<T> fileGenerator;
        private IConfiguration configuration;
        public ExtractGenerator(IFileGenerator<T> fileGenerator, IConfiguration configuration)
        {
            this.fileGenerator = fileGenerator;
            this.configuration = configuration;
        }

        public async Task GenerateExtract(IList<T> lstItems, ExtractConfig config)
        {
            var stream = fileGenerator.GenerateCsvFile(lstItems, config.Delimeter);
            var outputfilePath = configuration.GetValue<string>("OutputDataDirectory");
            var outputfileName = $"{outputfilePath}{config.Name}";
            var archiveFilePath = $"{outputfilePath}Archive";
            var dirInfo = new DirectoryInfo(archiveFilePath);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileInfo fs = new FileInfo(outputfileName);
            if(File.Exists(outputfileName))
            {
                File.Move(outputfileName, Path.Combine(archiveFilePath,$"{DateTime.Now.ToString("yyyyMMddhhmm")}_{fs.Name}" ));
            }
            using (var outputfs = File.Create(outputfileName))
            {
                await stream.CopyToAsync(outputfs);
            }
        }
    }
}
