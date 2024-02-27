namespace CBA.API.Models.Request
{
    public class AddTransactionRequest
    {
        public string sourceAccountNumber { get; set; }
        public string destinationAccountNumber { get; set; }
        public string destinationAccountName { get; set; }
        public string destinationBankCode { get; set; }
        public string transactionReference { get; set; } = Guid.NewGuid().ToString();
        public decimal transactionAmount { get; set; } = 0M;

    }
    public class TransactionWebhookRequest
    {
        public string transactionReference { get; set; }
        public string TransactionAmount { get; set; }
        public string transactionStatus { get; set; }
        public DateTime TransactionValueDate { get; set; }
    }
}
