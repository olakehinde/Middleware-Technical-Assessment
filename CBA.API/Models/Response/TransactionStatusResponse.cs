namespace CBA.API.Models.Response
{
    public class TransactionStatusResponse
    {
        public string transactionReference { get; set; }
        public string transactionStatus { get; set; }
        public DateTime transactionDate { get; set; }
        public string destinationAccountNumber { get; set; }
        public string transactionAmount { get; set; }
    }
}
