using CsvHelper;
using CsvHelper.Configuration;
using System.Data;
using System.Globalization;
using UniversalDataProcessorService.Extensions;

namespace UniversalDataProcessorService.FileHandler
{
    public interface IFileService
    {
        DataTable GetDataTableFromFile(MemoryStream stream);

    }
    public abstract class FileServiceBase : IFileService
    {
        public abstract DataTable GetDataTableFromFile(MemoryStream stream);

    }
    public class XmlFileService : FileServiceBase
    {
        public override DataTable GetDataTableFromFile(MemoryStream stream)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFileService<T>
    {
        IEnumerable<T> GetListFromFile(FileInfo fs);
    }
    public abstract class FileServiceBase<T> : IFileService<T>
    {
        public abstract IEnumerable<T> GetListFromFile(FileInfo fs);

    }
    public class DelimettedFileService<T> : FileServiceBase<T>
    {
        public override IEnumerable<T> GetListFromFile(FileInfo fs)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                PrepareHeaderForMatch = args => args.Header.StandardiseColumnTableName(),

            };
            IList<T> lstData = new List<T>();
            
            return GetRecords(fs, config);
        }

        private IEnumerable<T> GetRecords(FileInfo fs, CsvConfiguration config)
        {
            IEnumerable<T> records;
            using (var reader = new StreamReader(fs.FullName))

            using (var csv = new CsvReader(reader, config))
            {

                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
       
    }


}
