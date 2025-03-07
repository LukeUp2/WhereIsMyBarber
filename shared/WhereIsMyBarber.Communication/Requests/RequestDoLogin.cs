using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Communication.Requests
{
    public class RequestDoLogin
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}