using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Siteware.Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.Filters
{
    public class ReturnDefaultApiFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            string path = context.HttpContext.Request.Path.Value + context.HttpContext.Request.QueryString.Value;

            var exception = context.Exception;

            int statusCode = GetStatusCode(exception);

            context.Result = ResultError(statusCode, exception);
        }

        private int GetStatusCode(Exception exception)
        {
            var statusCodeAttribute = exception.GetType().GetCustomAttributes(typeof(HttpStatusCodeAttribute), true).FirstOrDefault();

            if (statusCodeAttribute != null)
                return (statusCodeAttribute as HttpStatusCodeAttribute).StatusCode;

            // Se a exception não possui um HttpStatusCodeAttribute definido, utiliza valores default.
            return 500;
        }

        private ObjectResult ResultError(int statusCode, Exception exception)
        {
            if (statusCode == 500)
            {
                return new ObjectResult(new ReturnError(exception.Message, exception.StackTrace))
                {
                    StatusCode = statusCode
                };
            }
            //Todas as outras: validacão, existente, inexistente, etc.
            return new ObjectResult(new ReturnValidation(exception.Message)) { StatusCode = statusCode };
        }
    }

    public class ReturnValidation
    {
        public string Message { get; set; }

        public ReturnValidation(string message)
        {
            Message = message;
        }
    }

    public class ReturnError : ReturnValidation
    {
        public string StackTrace { get; set; }

        public ReturnError(string message, string stackTrace)
            : base(message)
        {
            StackTrace = stackTrace;
        }
    }
}
