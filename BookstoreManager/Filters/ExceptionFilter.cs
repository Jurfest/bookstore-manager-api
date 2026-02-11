using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BookstoreManager.Contracts.Responses;
using BookstoreManager.Exceptions;

namespace BookstoreManager.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BookstoreManagerException bookstoreManagerException)
        {
            context.HttpContext.Response.StatusCode = (int)bookstoreManagerException.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(bookstoreManagerException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Unknown error"));
    }
}