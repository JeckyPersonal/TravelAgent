
using Invoice.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Invoice.MiddleWare
{
    public class ExceptionHandlerMiddleWare : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (SavedEntityException saveException)
            {
                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", saveException.Message);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new ValidationProblemDetails(dic));
            }
            catch (DuplicateEntityException duplicateException)
            {

                ModelStateDictionary dic = new ModelStateDictionary();
                dic.TryAddModelError("Id", duplicateException.Message);

                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsJsonAsync(new ValidationProblemDetails(dic));
            }
        }
    }
}
