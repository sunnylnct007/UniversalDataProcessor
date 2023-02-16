using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using UniversalDataProcessorModel;

namespace UniversalDataProcessorService.FileHandler
{
    public class FileGenerator<T> : IFileGenerator<T>
    {
        public MemoryStream GenerateCsvFile(IList<T> lst, ExtractConfig config)
        {
            var stream = new MemoryStream();
            var csvconfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = context => true,
                Delimiter= config.Delimeter ?? ",", HasHeaderRecord = config.ShowHeader
            };

            using (var writeFile = new StreamWriter(stream, leaveOpen: true))
            {

                var csv = new CsvWriter(writeFile, csvconfig);            
                csv.WriteRecords(lst);
                csv.Flush();
            }
            stream.Position = 0; //reset stream
            return stream;
            
        }
    }
}
