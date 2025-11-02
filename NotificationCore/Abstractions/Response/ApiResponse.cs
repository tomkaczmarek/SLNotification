using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Response
{
    public class ApiResponse<T> : ApiResponse
    {
        public T? Result { get; set; }

        public static ApiResponse<T> Success(T data) =>
            new ApiResponse<T> { Result = data };

        public static ApiResponse<T> Fail(string errorMessage) =>
            new ApiResponse<T> { ErrorMessage = errorMessage };

        public ApiResponse() { }

        public ApiResponse(HttpStatusCode? httpStatusCode) : base(httpStatusCode)
        {
        }
    }

    public class ApiResponse
    {
        private HttpStatusCode? _httpStatusCode;

        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
        public string? ErrorMessage { get; set; }
        public HttpStatusCode HttpStatusCode =>
            !string.IsNullOrEmpty(ErrorMessage)
            ? (_httpStatusCode.HasValue ? _httpStatusCode.Value : HttpStatusCode.BadRequest)
            : (_httpStatusCode.HasValue ? _httpStatusCode.Value : HttpStatusCode.OK);

        public ApiResponse() { }
        public ApiResponse(HttpStatusCode? httpStatusCode)
        {
            _httpStatusCode = httpStatusCode;
        }
    }
}
