using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Domain.Extensions
{
    public static class BooleanExtensions
    {
        public static bool IsFalse(this bool value) => value == false;
    }
}