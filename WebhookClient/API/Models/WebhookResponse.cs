using Newtonsoft.Json;
using System.Net;

namespace WebhookClient.API.Models
{
    public struct NoContent; // 16 kb

    public record WebhookResponse<T>
    {
        public T? Data { get; init; }

        [JsonIgnore] 
        public bool IsSuccess { get; init; }

        public List<string>? FailMessages { get; init; }

        [JsonIgnore] 
        public HttpStatusCode StatusCodes { get; set; }

        // static factory methods
        public static WebhookResponse<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new WebhookResponse<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCodes = statusCode
            };
        }

        public static WebhookResponse<T> Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new WebhookResponse<T>
            {
                IsSuccess = true,
                StatusCodes = statusCode
            };
        }

        public static WebhookResponse<T> Fail(List<string> messages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new WebhookResponse<T>
            {
                IsSuccess = false,
                FailMessages = messages,
                StatusCodes = statusCode
            };
        }

        public static WebhookResponse<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new WebhookResponse<T>
            {
                IsSuccess = false,
                FailMessages = new List<string> { message },
                StatusCodes = statusCode
            };
        }
    }
}
