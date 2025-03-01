using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Domain.Security.Cryptography
{
    public interface IPasswordEncrypter
    {
        public string Encrypt(string password);
    }
}