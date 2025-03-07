using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Exceptions.Exceptions
{
    public class ErrorOnValidationException : WhereIsMyBarberException
    {
        public readonly IList<string> errors;

        public ErrorOnValidationException(IList<string> errorsMessages) : base(string.Empty)
        {
            errors = errorsMessages;
        }
    }
}