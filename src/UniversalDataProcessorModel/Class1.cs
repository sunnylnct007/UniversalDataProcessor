using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversalDataProcessorModel
{
    public class Transaction
    {
        [Key]
        [Column(Order = 1)]
        public int SecurityId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PortfolioId { get; set; }

        public int TimeId { get; set; }
        public decimal Nominal { get; set; }

        public string Oms { get; set; }
        public string TransactionType { get; set; }
    }
}