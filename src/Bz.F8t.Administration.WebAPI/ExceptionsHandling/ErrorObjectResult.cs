﻿using Bz.F8t.Administration.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bz.F8t.Administration.WebAPI.ExceptionsHandling;

internal class ErrorObjectResult : ObjectResult
{
    public ErrorObjectResult(object error, int statusCode)
                : base(error)
    {
        StatusCode = statusCode;
    }

    public static ErrorObjectResult Create(Exception exception)
    {
        var message = exception.Message;
        var httpStatusCode = (int)HttpStatusCode.InternalServerError;

        switch (exception)
        {
            case ValidationException:
            case FluentValidation.ValidationException:
                httpStatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case NotFoundException:
                httpStatusCode = (int)HttpStatusCode.NotFound;
                break;
            case InvalidOperationException:
                httpStatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        return new ErrorObjectResult(new ErrorResponseDto(message), httpStatusCode);
    }
}
