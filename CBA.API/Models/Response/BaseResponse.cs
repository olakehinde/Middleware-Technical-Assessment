namespace CBA.API.Models.Response
{
    public sealed class BaseResponse<T>
    {
        public BaseResponse()
        {

        }
        public string? responseCode { get; set; }
        public string? responseMessage { get; set; }
        public T? responseData { get; set; }

        public BaseResponse(T data)
        {
            this.responseCode = "00";
            this.responseMessage = "Request Completed";
            this.responseData = data;
        }

        public BaseResponse(bool IsSuccessCode)
        {
            if (IsSuccessCode)
            {
                this.responseCode = "00";
                this.responseMessage = "Request Completed";
            }
            else
            {
                this.responseCode = "99";
                this.responseMessage = "Request Failed";
            }
        }

        public BaseResponse(bool IsSuccessCode, string msg)
        {
            if (IsSuccessCode)
            {
                this.responseCode = "00";
                this.responseMessage = string.IsNullOrEmpty(msg) ? "Request Completed" : msg;
            }
            else
            {
                this.responseCode = "99";
                this.responseMessage = msg;
            }

        }
        public BaseResponse<T> SuccessResponse(string responseMessage, T data)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                responseData = data,
                responseMessage = responseMessage,
                responseCode = "00"
            };
            return response;
        }

        public BaseResponse<T> FailureResponse(string responMessage, T data)
        {
            BaseResponse<T> response = new BaseResponse<T>()
            {
                responseData = data,
                responseCode = "99",
                responseMessage = responseMessage
            };

            return response;
        }
    }
}
