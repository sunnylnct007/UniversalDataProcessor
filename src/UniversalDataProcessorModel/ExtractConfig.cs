using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataProcessorModel
{
    public  class ExtractConfig
    {
        [Key]
        public string Name { get; set; }
        public string Delimeter { get; set; }

        public string Extension { get; set; }

        public bool ShowHeader { get; set; }
    }
}
