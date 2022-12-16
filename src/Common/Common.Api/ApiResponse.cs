using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Api;

public class ApiResponse
{
    public static ApiResponse Success()
    {
        return new ApiResponse
        {
            Successful = true
        };
    }
    public static ApiResponse Success(object result)
    {
        return new ApiResponse
        {
            Data = result,
            Successful = true
        };
    }

    public static ApiResponse Fail(string code, string message)
    {
        return new ApiResponse
        {
            Error = new ErrorDetail
            {
                ErrorCode = code,
                Message = message
            },
            Successful = false
        };
    }
    public static ApiResponse Fail(string message, ErrorDetail detail)
    {
        return new ApiResponse
        {
            Error = detail,
            Successful = false
        };
    }


    [JsonPropertyName("successful")]
    public bool Successful { get; set; }

    [JsonPropertyName("data")]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object Data { get; set; }

    [JsonPropertyName("error")]
    public ErrorDetail Error { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this,
            new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
    }
}