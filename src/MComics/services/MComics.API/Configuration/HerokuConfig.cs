using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MComics.API.Configuration
{
    public static class HerokuConfig
    {
        public static IHostBuilder UserPort(this IHostBuilder builder)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            if (string.IsNullOrEmpty(port))
            {
                return builder;
            }
            return builder.UseUrls($"http://+:{port}");
        }
    }
}
