using System.Data;

namespace UniversalDataProcessorService.FileHandler
{
    public interface IFileFactory
    {
      Task<DataTable> GetDataTableFromFile(FileInfo file);
    }
}
