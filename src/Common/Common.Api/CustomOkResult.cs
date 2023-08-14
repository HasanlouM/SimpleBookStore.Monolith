using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Api;

public class CustomOkResult : OkResult
{
    private readonly string _message = "Operation completed successfully";

    public CustomOkResult()
    {

    }
    public CustomOkResult(string message)
    {
        _message = message;
    }

    public override void ExecuteResult(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var rsp = ApiResponse.Success(_message);
        context.HttpContext.Response.StatusCode = StatusCode;
        context.HttpContext.Response.WriteAsync(rsp.ToString());
    }
}