using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Exceptions.Exceptions
{
    public class WhereIsMyBarberException : Exception
    {
        public WhereIsMyBarberException(string message) : base(message)
        {

        }
    }
}