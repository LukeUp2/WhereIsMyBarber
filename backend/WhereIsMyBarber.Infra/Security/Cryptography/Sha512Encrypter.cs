using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WhereIsMyBarber.Domain.Security.Cryptography;

namespace WhereIsMyBarber.Infra.Security.Cryptography
{
    public class Sha512Encrypter : IPasswordEncrypter
    {

        public string Encrypt(string password)
        {
            //Implementar no futuro
            //var passwordWithAdditionalKey = $"{password}{_additionalKey}";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA512.HashData(bytes);

            return ConvertBytesToString(hashBytes);
        }

        private static string ConvertBytesToString(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            foreach (var b in bytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}