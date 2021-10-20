using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.ModelBinding;
using Vehicle.Core.Exceptions;
using Vehicle.Presentation.API.Helpers.Extensions;

namespace Vehicle.Presentation.API.Models
{
    public class HttpError
    {
        public HttpError(HttpErrorDetail error)
        {
            Error = error;
        }

        public HttpErrorDetail Error { get; }
    }

    public abstract class HttpErrorDetail
    {
        protected HttpErrorDetail(HttpStatusCode status, string error, string description)
        {
            Status = status;
            Error = error;
            Description = description;
        }

        public HttpStatusCode Status { get; }
        public string Error { get; }
        public string Description { get; }
        //public int Code { get; set; }
    }

    public class BadRequestHttpErrorDetail : HttpErrorDetail
    {
        public BadRequestHttpErrorDetail(ModelStateDictionary modelState)
            : base(HttpStatusCode.BadRequest, GetError(modelState), GetDetail(modelState))
        {
        }

        private static string GetError(ModelStateDictionary modelState)
        {
            var target = modelState.Values.FirstOrDefault()?.Errors.FirstOrDefault();

            return target?.Exception?.GetType()?.Name ?? target?.GetType()?.Name;
        }

        private static string GetDetail(ModelStateDictionary modelState)
        {
            var target = modelState.Values.FirstOrDefault()?.Errors?.FirstOrDefault();

            return target?.Exception?.Message ?? target?.ErrorMessage;
        }
    }

    public class UnprocessableEntityHttpErrorDetail : HttpErrorDetail
    {
        public UnprocessableEntityHttpErrorDetail(ModelStateDictionary modelState)
            : base(HttpStatusCode.UnprocessableEntity, "FieldsValidationError", "Uno o mas campos tienen errores de validación.")
        {
            Fields = modelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(
                    x => x.Key.ToCamelCase(),
                    x => x.Value.Errors
                        .Select(y => y.ErrorMessage ?? y.Exception.Message)
                        .ToArray());
        }

        public IDictionary<string, string[]> Fields { get; }
    }

    public class ConflictHttpErrorDetail : HttpErrorDetail
    {

        public ConflictHttpErrorDetail(Exception ex)
            : base(HttpStatusCode.Conflict, ex.GetType().Name, ex.Message)
        {
            //if (ex is BusinessException BusinessEx)
            //{
            //    Code = (int)BusinessEx.Code;
            //    CodeDesc = BusinessEx.Code.ToString("g");
            //}

        }

        //public int? Code { get; set; } = null;
        //public string CodeDesc { get; set; } = null;

    }

    public class InternalServerErrorHttpErrorDetail : HttpErrorDetail
    {
        public InternalServerErrorHttpErrorDetail()
            : base(HttpStatusCode.InternalServerError, "UnknownError", "Ocurrió un error no esperado.")
        {
        }
    }

    public class InternalServerErrorHttpErrorDetailDebug : InternalServerErrorHttpErrorDetail
    {
        public InternalServerErrorHttpErrorDetailDebug(ExceptionInfo exception)
            : base()
        {
            Exception = exception;
        }

        public ExceptionInfo Exception { get; }
    }

    public class UnauthorizedHttpErrorDetail : HttpErrorDetail
    {
        public UnauthorizedHttpErrorDetail()
            : base(HttpStatusCode.Unauthorized, "Unauthorized", "El usuario no está autorizado para realizar la acción.")
        {
        }
    }

    public class ForbiddenHttpErrorDetail : HttpErrorDetail
    {
        public ForbiddenHttpErrorDetail()
            : base(HttpStatusCode.Forbidden, "Forbidden", "Se le ha denegado el permiso al usuario para realizar la acción.")
        {
        }
    }

    public class ExceptionInfo
    {
        public ExceptionInfo(Exception exception)
        {
            Message = exception.Message;
            Stacktrace = exception.StackTrace;
        }

        public string Message { get; }
        public string Stacktrace { get; }
    }
}
