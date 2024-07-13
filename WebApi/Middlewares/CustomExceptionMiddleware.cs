using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    /// <summary>
    /// Custom Exception Middleware hata yönetimi için kullanýlýr.
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
           _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch=Stopwatch.StartNew();
            try
            {
                string message="[Request]  HTTP "+ context.Request.Method+" - "+context.Request.Path;
                _loggerService.Write(message); 

                await _next(context);
                watch.Stop();

                message="[Response] HTTP "+context.Request.Method+" - "+context.Request.Path+" responded "+context.Response.StatusCode+" in "+watch.Elapsed.TotalMilliseconds+" ms ";
               _loggerService.Write(message);                
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleExcepiton(context,ex,watch);
            }

            
        }

        /// <summary>
        /// HandleExcepiton metodu hata durumunda loglama yapar ve hata mesajýný döner.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <param name="watch"></param>
        /// <returns></returns>
        private Task HandleExcepiton(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType="application/json";
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
            string message="[Error]    HTTP "+context.Request.Method+" - "+context.Response.StatusCode+" Error Message "+ex.Message+" in "+watch.Elapsed.TotalMilliseconds+" ms";
            _loggerService.Write(message);
            var result =JsonConvert.SerializeObject(new { error =ex.Message},Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }


    /// <summary>
    /// CustomExceptionMiddlewareExtension sýnýfý Middleware sýnýfýný kullanmak için gerekli extension metodu saðlar.
    /// </summary>
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}