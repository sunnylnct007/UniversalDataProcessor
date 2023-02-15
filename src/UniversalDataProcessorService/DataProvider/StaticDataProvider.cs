using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService.DataProvider
{
    public abstract class StaticDataProvider<T> : IStaticDataProvider<T>
    {
        protected IConfiguration configuration;
        private IFileReader<T> fileReader;
        public StaticDataProvider(IConfiguration configuration, IFileReader<T> fileReader)
        {
            this.configuration = configuration;
            this.fileReader = fileReader;
        }
        protected abstract string FileName { get; }
        protected string StaticDataFilePath => configuration.GetValue<string>("StaticDataDirectory");
        public IList<T> GetFileData()
        {
            var fi = new FileInfo($"{StaticDataFilePath}{FileName}");
            return fileReader.ReadFile(fi.OpenRead());
        }
    }
}
