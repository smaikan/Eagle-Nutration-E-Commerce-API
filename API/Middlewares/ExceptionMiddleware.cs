using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // bir sonraki middleware'e geç
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex); // hata olursa yakala
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Beklenmeyen bir hata oluştu.",
                Detail = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }

}
