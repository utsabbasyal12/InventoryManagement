using Microsoft.AspNetCore.Http;
using Shared.Wrapper;
using System.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace Shared.MiddleWare
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = await Response<string>.FailAsync(error.Message);

                switch (error)
                {
                    case SqlException e:
                        // custom application error
                        response.StatusCode = (e.Number == 51002) ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError; ;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException e:
                        // unAuthorized error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
