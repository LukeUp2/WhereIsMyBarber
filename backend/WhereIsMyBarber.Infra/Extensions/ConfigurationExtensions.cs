using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WhereIsMyBarber.Infra.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("Default")!;
        }
    }
}