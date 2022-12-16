using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Api;

public class CustomOkResult : OkResult
{
    private const string Message = "Operation completed successfully";

    public override void ExecuteResult(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var rsp = ApiResponse.Success(Message);
        context.HttpContext.Response.StatusCode = StatusCode;
        context.HttpContext.Response.WriteAsync(rsp.ToString());
    }
}