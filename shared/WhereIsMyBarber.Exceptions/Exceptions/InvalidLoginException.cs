using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Exceptions.Exceptions
{
    public class InvalidLoginException : WhereIsMyBarberException
    {
        public InvalidLoginException() : base("Email ou senha inválidos")
        {

        }
    }
}