using System.Text.Json.Serialization;

namespace Common.Api;

public class ErrorDetail
{
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}