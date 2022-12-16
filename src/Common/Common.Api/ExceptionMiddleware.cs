using Common.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Common.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"Something went wrong: {ex}{Environment.NewLine}{Environment.NewLine}");
                await HandleBusinessException(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}{Environment.NewLine}{Environment.NewLine}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleBusinessException(
            HttpContext context, BusinessException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = new ErrorDetail
            {
                ErrorCode = exception.Code.ToString(),
                Message = exception.Message
            };
            var response = ApiResponse.Fail("Something went wrong", error).ToString();
            return context.Response.WriteAsync(response);
        }

        private static Task HandleExceptionAsync(
            HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorMessage = "Something went wrong";
            if (exception.Source == "Microsoft.AspNetCore.Authorization")
            {
                errorMessage += ", you don't have permission.";
            }

            var response = ApiResponse.Fail("100", errorMessage).ToString();
            return context.Response.WriteAsync(response);
        }
    }
}