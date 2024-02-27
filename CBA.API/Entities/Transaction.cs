using System.ComponentModel.DataAnnotations;

namespace CBA.API.Entities
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        public string SourceAccountNumber { get; set; }
        public string SourceAccountName { get; set; }
        public string DestinationAccountNumber { get; set; }
        public string DestinationAccountName { get; set; }
        public string DestinationBankCode { get; set; }
        public string TransactionReference { get; set; } = Guid.NewGuid().ToString();
        public decimal TransactionAmount { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate = DateTime.Now;
    }
}
