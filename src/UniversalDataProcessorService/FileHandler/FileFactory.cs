using System.Data;

namespace UniversalDataProcessorService.FileHandler
{
    public class FileFactory : IFileFactory
    {
        private IFileHandlerFactory fileHandlerFactory;
        private ILogger<FileFactory> logger;
        public FileFactory(IFileHandlerFactory fileHandlerFactory, ILogger<FileFactory> logger)
        {
            this.fileHandlerFactory = fileHandlerFactory;
            this.logger = logger;
        }

        public async Task<DataTable> GetDataTableFromFile(FileInfo file)
        {
            var fileService = fileHandlerFactory.GetFileService(file.Extension, file.Name);
            DataTable datatable = new DataTable();
            using (var stream = new MemoryStream())
            {

                using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    
                    await fs.CopyToAsync(stream);                   
                    stream.Seek(0, SeekOrigin.Begin);
                    datatable = fileService.GetDataTableFromFile(stream);
                    datatable.TableName = file.Name;
                }

            }

            return datatable;
        }


       
    }
}
