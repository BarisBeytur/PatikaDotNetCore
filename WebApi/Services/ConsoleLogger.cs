using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    /// <summary>
    /// ConsoleLogger sýnýfý ILoggerService arayüzünden türetilmiþtir ve konsola loglama yapar.
    /// </summary>
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - "+message);
        }
    }
}