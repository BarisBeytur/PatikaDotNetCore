using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApi.Middlewares
{
    /// <summary>
    /// BookMiddleware s�n�f� RequestDelegate t�r�nden bir parametre al�r ve Invoke metodu ile middleware i�lemlerini ger�ekle�tirir.
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
    /// BookMiddlewareEntension s�n�f� IApplicationBuilder t�r�nden bir parametre al�r ve UseBook metodu ile BookMiddleware s�n�f�n� kullan�r.
    /// </summary>
    static public class BookMiddlewareEntension
    {
        public static IApplicationBuilder UseBook(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BookMiddleware>();
        }
    }
}