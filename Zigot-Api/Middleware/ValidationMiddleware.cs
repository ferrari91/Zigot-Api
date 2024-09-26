using Newtonsoft.Json;
using System.Net;
using Zigot.Core.Domain.Abstractions.Exceptions;
using Zigot_Api.Wrapper._Error;
using Zigot_Api.Wrapper.Exceptions;
using Zigot_Api.Wrapper.Result;

namespace Zigot_Api.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            string jsonResponse = string.Empty;
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new BaseResult<string>(new Error(ErrorCode.Exception, error?.Message, error?.Source));

                switch (error)
                {
                    case ValidationCustomException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors.Select(p => new Error(ErrorCode.ModelStateNotValid, p.ErrorMessage, p.PropertyName)).ToList();
                        break;
                    case ExceptionAbstraction e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = new List<Error>() { new Error(ErrorCode.ModelStateNotValid, e.Message, e.Model)};
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}