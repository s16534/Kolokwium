using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.Exceptions
{
    public class WrongNewPerformanceDataException : Exception
    {
        public WrongNewPerformanceDataException(string msg) : base(msg)
        {
        }
        public WrongNewPerformanceDataException(string msg, Exception e) : base(msg, e)
        {
        }
        public WrongNewPerformanceDataException()
        {
        }
    }
}
