using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace UniversalDataProcessorService.FileHandler
{
    public class FileGenerator<T> : IFileGenerator<T>
    {
        public MemoryStream GenerateCsvFile(IList<T> lst, string delimeter)
        {
            var stream = new MemoryStream();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = context => true,
                Delimiter=delimeter?? ","
            };

            using (var writeFile = new StreamWriter(stream, leaveOpen: true))
            {

                var csv = new CsvWriter(writeFile, config);            
                csv.WriteRecords(lst);
                csv.Flush();
            }
            stream.Position = 0; //reset stream
            return stream;
            
        }
    }
}
