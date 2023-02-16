using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataProcessorModel.Decorator
{
    public class TransactionDecorator:Transaction
    {       

        public Portfolio Portfolio { get; set; }
        public Security Security { get; set; }
    }
}
