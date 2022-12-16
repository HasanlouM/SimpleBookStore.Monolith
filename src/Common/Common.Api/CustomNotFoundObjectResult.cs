using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Api;

public class CustomNotFoundObjectResult : NotFoundObjectResult
{
    public CustomNotFoundObjectResult(object value) : base(value)
    {
    }

    public override void ExecuteResult(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var rsp = ApiResponse.Success(Value);
        context.HttpContext.Response.StatusCode = StatusCode.GetValueOrDefault();
        context.HttpContext.Response.WriteAsync(rsp.ToString());
    }
}