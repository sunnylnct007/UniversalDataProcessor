using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalDataProcessorModel;
using UniversalDataProcessorService.FileHandler;

namespace UniversalDataProcessorService.DataProvider
{
    public interface IStaticDataProvider<T>
    {
        IList<T> GetFileData();
    }
    public class SecurityDataProvider : StaticDataProvider<Security>
    {
              
        public SecurityDataProvider(IFileReader<Security> fileReader, IConfiguration configuration):base(configuration, fileReader)
        {           
            this.configuration = configuration;
        }
        protected override string FileName => "securities.csv";


    }
}
