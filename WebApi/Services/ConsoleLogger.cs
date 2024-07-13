using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    /// <summary>
    /// ConsoleLogger s�n�f� ILoggerService aray�z�nden t�retilmi�tir ve konsola loglama yapar.
    /// </summary>
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - "+message);
        }
    }
}