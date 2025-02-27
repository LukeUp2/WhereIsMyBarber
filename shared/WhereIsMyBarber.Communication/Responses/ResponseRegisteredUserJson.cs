using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Communication.Responses
{
    public class ResponseRegisteredUserJson
    {
        public string Name { get; set; } = string.Empty;
        public ResponseTokensJson Tokens { get; set; } = default!;
        //Esse "default!" é pra dizer pro compilador que esse parametro nao vai ser nulo
    }
}