using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Exceptions.Exceptions
{
    public class ResponseErrorJson
    {
        public IList<string> Errors { get; set; }

        public ResponseErrorJson(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }
    }
}