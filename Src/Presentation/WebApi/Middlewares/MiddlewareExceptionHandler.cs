#region UsingAndNamespace

using System.Net;
using System.Text.Json;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebApi.Middlewares; 
#endregion

public class MiddlewareExceptionHandler
{
    #region CtorAndInjectjtion
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILoggerFactory _loggerFactory;
    private readonly RequestDelegate _requestDelegate;
    public MiddlewareExceptionHandler(IWebHostEnvironment webHostEnvironment, ILoggerFactory loggerFactory, RequestDelegate requestDelegate)
    {
        _webHostEnvironment = webHostEnvironment;
        _loggerFactory = loggerFactory;
        _requestDelegate = requestDelegate;
    }
    #endregion

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);//do request if throw an error execute catch
        }
        catch (Exception e)
        {
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            #region CreateDefaultError
            var result = HandleServerError(httpContext, e, options);
            #endregion

            #region CheckAndChangeError
            result = HandleRequestResult(httpContext, e, result, options); 
            #endregion

            await httpContext.Response.WriteAsync(result);
        }
    }
    #region MethodHandleServerError=>Default
    private static string HandleServerError(HttpContext httpContext, Exception e, JsonSerializerOptions options)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500
        var result = JsonSerializer.Serialize(new ApiToReturn(e.Message, 500), options);
        return result;
    }
    #endregion

    #region MethodHandleServerError=>Change
    private string HandleRequestResult(HttpContext httpContext, Exception e, string result, JsonSerializerOptions options)
    {
        switch (e)
        {
            case NotFoundEntityException notFoundException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new ApiToReturn(notFoundException.Messages, notFoundException.Message, 404, e.Message), options);
                break;
            case BadRequestEntityException badRequestException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new ApiToReturn(badRequestException.Messages, badRequestException.Message, 400, e.Message), options);
                break;
            case ValidationEntityException validationEntityException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new ApiToReturn(validationEntityException.Messages, validationEntityException.Message, 400, e.Message), options);
                break;
        }
        return result;
    } 
    #endregion
}