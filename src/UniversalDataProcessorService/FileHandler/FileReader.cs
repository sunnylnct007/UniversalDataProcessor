using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace UniversalDataProcessorService.FileHandler
{
    public class FileReader<T> : IFileReader<T>
    {
      //  private ILogger logger;
        public FileReader()
        {
            //this.logger = logger;
        }
        public IList<T> ReadFile(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var delimiter = DetectDelimiter(reader);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {

                    Delimiter = delimiter,
                    BadDataFound = context =>
                    {
                        //logger.LogError($"Bad data found on row '{context.RawRecord}'");

                    },
                    HasHeaderRecord = true,
                    MissingFieldFound = null

                };
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<T>().ToList();
                }
            }
            
        }
        private string DetectDelimiter(StreamReader reader)
        {
            // assume one of following delimiters
            var possibleDelimiters = new List<string> { ",", ";", "\t", "|" };

            var headerLine = reader.ReadLine();

            reader.BaseStream.Position = 0;
            reader.DiscardBufferedData();

            foreach (var possibleDelimiter in possibleDelimiters)
            {
                if (headerLine.Contains(possibleDelimiter))
                {
                    return possibleDelimiter;
                }
            }

            return possibleDelimiters[0];
        }
    }
}
