using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.Exceptions
    {
    public class NoEventException : Exception
    {
        public NoEventException(string msg) : base(msg)
        {
        }
        public NoEventException(string msg, Exception e) : base(msg, e)
        {
        }
        public NoEventException()
        {
        }
    }
}
