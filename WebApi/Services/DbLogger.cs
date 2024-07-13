using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    /// <summary>
    /// DbLogger Db'ye loglama yapmak amacýyla kullanýlabilir.
    /// </summary>
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DbLogger] - "+message);
        }
    }
}