using CBA.API.Models.Request;
using CBA.API.Models.Response;

namespace CBA.API.Interface
{
    public interface ICBSService
    {
        public Task<BaseResponse<bool>> AddTransactionAsync(AddTransactionRequest param, CancellationToken token);
        public Task<BaseResponse<TransactionStatusResponse>> ConfirmTransacitonStatusAsync(string transactionReferende, CancellationToken token);

        public Task<BaseResponse<bool>> AddTransactionUpdate(TransactionWebhookRequest param, CancellationToken token);
    }
}
