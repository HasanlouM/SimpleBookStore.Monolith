using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Common.Api;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public abstract class MainController : ControllerBase
{
    protected string ApiVersion => $"v{HttpContext.GetRequestedApiVersion()?.ToString() ?? "1"}";

    public override OkResult Ok()
    {
        return new CustomOkResult();
    }

    public override OkObjectResult Ok([ActionResultObjectValue] object value)
    {
        var rsp = ApiResponse.Success(value);
        return base.Ok(rsp);
    }

    public override CreatedResult Created(string uri, object value)
    {
        var rsp = ApiResponse.Success(value);
        return base.Created(uri, rsp);
    }

    public override NotFoundObjectResult NotFound(object value)
    {
        return new CustomNotFoundObjectResult(value);
    }

    protected ObjectResult Fail(int statusCode, string message)
    {
        var rsp = ApiResponse.Fail("100", message);
        return base.StatusCode(statusCode, rsp);
    }
}