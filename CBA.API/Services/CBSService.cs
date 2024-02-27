using CBA.API.Entities;
using CBA.API.Enum;
using CBA.API.Interface;
using CBA.API.Models.Request;
using CBA.API.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;

namespace CBA.API.Services
{
    public class CBSService : ICBSService
    {

        public async Task<BaseResponse<bool>> AddTransactionAsync(AddTransactionRequest param, CancellationToken token)
        {
            using (var context = new CBSContext())
            {
                var entry = new Transaction()
                {
                     DestinationAccountName = param.destinationAccountName,
                     DestinationAccountNumber = param.destinationAccountNumber,
                     DestinationBankCode = param.destinationBankCode,
                     SourceAccountNumber = param.sourceAccountNumber,
                     TransactionAmount = param.transactionAmount,
                     TransactionReference = param.transactionReference,
                     TransactionStatus = nameof(TransactionStatusType.PENDING),
                     TransactionDate = DateTime.Now,

                };
                await context.transactions.AddAsync(entry, token);
                await context.SaveChangesAsync(token);
            }
            return new BaseResponse<bool>(true) { responseData = true, responseMessage = "Transaction posted succesfully" };
        }

        public async Task<BaseResponse<bool>> AddTransactionUpdate(TransactionWebhookRequest param, CancellationToken token)
        {
            using (var context = new CBSContext())
            {
                var transactionInfo = await context.transactions.Where(x => x.TransactionReference == param.transactionReference).FirstOrDefaultAsync(token);

                if(transactionInfo is not null)
                {
                    transactionInfo.TransactionStatus = param.transactionStatus;
                    transactionInfo.TransactionAmount = decimal.Parse(param.TransactionAmount);
                }
                context.transactions.Update(transactionInfo!);
                await context.SaveChangesAsync(token);
                return new BaseResponse<bool>(true) { responseData = true };
            }
        }

        public async Task<BaseResponse<TransactionStatusResponse>> ConfirmTransacitonStatusAsync(string transactionReference, CancellationToken token)
        {
            using (var context = new CBSContext())
            {
                var transactionInfo = await context.transactions.FirstOrDefaultAsync(x => x.TransactionReference == transactionReference, token);

                if(transactionInfo is not null)
                {
                    return new BaseResponse<TransactionStatusResponse>(true) { responseData = new TransactionStatusResponse() { 
                    
                         transactionStatus = transactionInfo.TransactionStatus,
                         transactionAmount = transactionInfo.TransactionAmount.ToString(),
                         transactionReference = transactionInfo.TransactionReference,
                         transactionDate = transactionInfo.TransactionDate
                    }};
                }
                return new BaseResponse<TransactionStatusResponse>(false) { responseMessage = $"No record found for {transactionReference}" };
            }
        }
    }
}
