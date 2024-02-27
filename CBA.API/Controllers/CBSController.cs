using CBA.API.Interface;
using CBA.API.Models.Request;
using CBA.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CBA.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/cbs")]
    public class PaymentController : ControllerBase
    {
        private readonly ICBSService _service;

        public PaymentController(ICBSService service)
        {
            _service = service;
        }

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BaseResponse<bool>))]
        [HttpPost("transaction")]
        public async Task<IActionResult> AddTransacion([FromBody] AddTransactionRequest param, CancellationToken token)
        {
            var resp = await _service.AddTransactionAsync(param, token);
            return resp.responseCode!.Equals("00") ? Ok(resp) : BadRequest(resp);
        }

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BaseResponse<bool>))]
        [HttpGet("transaction/{transactionReference}")]
        public async Task<IActionResult> GetTransactionStatus([FromRoute] string transactionReference, CancellationToken token)
        {
            var resp = await _service.ConfirmTransacitonStatusAsync(transactionReference, token);
            return resp.responseCode!.Equals("00") ? Ok(resp) : BadRequest(resp);
        }

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BaseResponse<bool>))]
        [HttpPut("transaction-webhook")]
        public async Task<IActionResult> TransactionWebhook([FromBody] TransactionWebhookRequest param, CancellationToken token)
        {
            var resp = await _service.AddTransactionUpdate(param, token);
            return resp.responseCode!.Equals("00") ? Ok(resp) : BadRequest(resp);
        }
    }
}
