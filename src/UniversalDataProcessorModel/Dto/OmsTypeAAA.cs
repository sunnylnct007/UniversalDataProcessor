using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataProcessorModel.Dto
{
    public class OmsTypeAAA
    {
        public string ISIN { get; set; }
        public string PortfolioCode { get; set; }
        public decimal Nominal { get; set; }
        public string TransactionType { get; set; }

    }
    public class OmsTypeBBB
    {
        public string Cusip { get; set; }
        public string PortfolioCode { get; set; }
        public decimal Nominal { get; set; }
        public string TransactionType { get; set; }

    }
    public class OmsTypeCCC
    {
       
        public string PortfolioCode { get; set; }
        public string Ticker { get; set; }
        public decimal Nominal { get; set; }
        public string TransactionType { get; set; }

    }
}
