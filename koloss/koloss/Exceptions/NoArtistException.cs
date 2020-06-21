using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koloss.Exceptions
    {
    public class NoArtistException : Exception
    {
        public NoArtistException(string msg) : base(msg)
        {
        }
        public NoArtistException(string msg, Exception e) : base(msg, e)
        {
        }
        public NoArtistException()
        {
        }
    }
}
