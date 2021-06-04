using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MComics.Core.Services
{
    public static class ConfigurationExtensions
    {
        public static string GetKeysConnection (this IConfiguration configuration, string name)
        {
            return configuration.GetSection("IntegrationKeys")[name];
        }
    }
}
