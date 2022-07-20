using ECommerce.Application.Common.DTOs.Response;
using ECommerce.Application.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (StateException ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }           
        }

        private static Task HandleExceptionAsync(HttpContext context, StateException exception, IWebHostEnvironment env)
        {
            var status = new ResponseState( 400, exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status.StatusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(status));
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
