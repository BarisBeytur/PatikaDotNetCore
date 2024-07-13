using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApi.Middlewares
{
    /// <summary>
    /// BookMiddleware sýnýfý RequestDelegate türünden bir parametre alýr ve Invoke metodu ile middleware iþlemlerini gerçekleþtirir.
    /// </summary>
    public class BookMiddleware
    {
        private readonly RequestDelegate _next;
        public  BookMiddleware(RequestDelegate next)
        {
            _next=next;
        }  
        public async  Task Invoke(HttpContext context)
        {
            Console.WriteLine("Hello World!");
            await _next.Invoke(context);
            Console.WriteLine("Bye World!");
        }
    }

    /// <summary>
    /// BookMiddlewareEntension sýnýfý IApplicationBuilder türünden bir parametre alýr ve UseBook metodu ile BookMiddleware sýnýfýný kullanýr.
    /// </summary>
    static public class BookMiddlewareEntension
    {
        public static IApplicationBuilder UseBook(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BookMiddleware>();
        }
    }
}