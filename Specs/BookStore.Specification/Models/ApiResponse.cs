using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.Test.Specs.Models
{
    internal class ApiResponse<T>
    {
        [JsonPropertyName("successful")]
        public bool Successful { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("error")]
        public ErrorDetail Error { get; set; }
    }
    internal class ErrorDetail
    {
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
