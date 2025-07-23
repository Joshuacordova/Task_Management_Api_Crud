using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Services.Description;

namespace CrudApi.Infrastructure
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            if (exception is TaskNotFoundException)
                status = HttpStatusCode.NotFound;
            else if (exception is BadRequestException)
                status = HttpStatusCode.BadRequest;

            context.Response = context.Request.CreateErrorResponse(status, exception.Message);
        }
    }
}

    
