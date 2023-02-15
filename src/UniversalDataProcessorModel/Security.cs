namespace UniversalDataProcessorModel
{
    public class Security
    {
        public int SecurityId { get; set; }
        public string ISIN { get; set; }
        public string Ticker { get; set; }
        public string CUSIP { get; set; }
    }

    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string PortfolioCode { get; set; }
       
    }
}
