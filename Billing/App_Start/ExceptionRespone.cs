using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace Billing
{
    public class ExceptionResponeAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var respone = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (actionExecutedContext.Exception is BadRequestException)
            {
                respone = new HttpResponseMessage(HttpStatusCode.BadRequest);
                respone.ReasonPhrase = "Wrong Parameters";
            }
            if (actionExecutedContext.Exception is ConflictException)
            {
                respone = new HttpResponseMessage(HttpStatusCode.Conflict);
                respone.ReasonPhrase = "Conflict data";
            }
            if (actionExecutedContext.Exception is ForbiddenException)
            {
                respone = new HttpResponseMessage(HttpStatusCode.Forbidden);
                respone.ReasonPhrase = "Forbidden";
            }
            if (actionExecutedContext.Exception is NotFoundException)
            {
                respone = new HttpResponseMessage(HttpStatusCode.NotFound);
                respone.ReasonPhrase = "Not Found";
            }

            var Message = JsonConvert.SerializeObject(new {actionExecutedContext.Exception.Message});
            respone.Content = new StringContent(Message);
            actionExecutedContext.Response = respone;
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string Message) : base(Message)
        {
        }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string Message) : base(Message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message)
        {
        }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string Message) : base(Message)
        {
        }
    }
}