using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;
using Vehicle.Core.Exceptions;
using Vehicle.Presentation.API.Models;

namespace Vehicle.Presentation.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

  

        public async Task Invoke(
            HttpContext context,
            IHostingEnvironment environment,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, logger, ex);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            //IHostingEnvironment environment,
            ILogger<ExceptionHandlingMiddleware> logger,
            Exception exception)
        {
            HttpError httpError = null;
            if (exception is BusinessException)
            {
                httpError = new HttpError(new ConflictHttpErrorDetail(exception));
                logger.LogWarning(exception, "Bad request received, conflict ocurred");
            }
            else
                httpError = new HttpError(new InternalServerErrorHttpErrorDetailDebug(new ExceptionInfo(exception)));


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpError.Error.Status;
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(
                    httpError,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
