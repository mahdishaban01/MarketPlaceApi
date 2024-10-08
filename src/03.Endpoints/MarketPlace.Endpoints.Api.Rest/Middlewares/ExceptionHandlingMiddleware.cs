﻿using MarketPlace.Endpoints.Api.Rest.Models.Responses;
using System.Net;
using System.Text.Json;

namespace MarketPlace.Endpoints.Api.Rest.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ErrorResponse
        {
            Success = false
        };
        switch (exception)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Invalid token"))
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    errorResponse.Message = ex.Message;
                    break;
                }
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;
            case KeyNotFoundException ex:
                response.StatusCode = (int) HttpStatusCode.NotFound;
                errorResponse.Message = ex.Message;
                break;
            case InvalidOperationException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;
            case ArgumentOutOfRangeException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;
            case ArgumentNullException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;
            case ArgumentException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;
            case NotImplementedException ex:
                response.StatusCode = (int)HttpStatusCode.NotImplemented;
                errorResponse.Message = ex.Message;
                break;
            default:
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorResponse.Message = "Internal Server errors. Check Logs!";
                break;
        }

        logger.LogError(exception.Message);
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}