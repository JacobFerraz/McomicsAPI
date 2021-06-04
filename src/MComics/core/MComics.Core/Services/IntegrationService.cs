using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Core.Services
{
    public static class IntegrationService
    {
        public static string GerarHashCode(string dateCurrent, string privateKey, string publicKey)
        {
            var provider = MD5.Create();
            byte[] bytes = provider.ComputeHash(Encoding.ASCII.GetBytes(dateCurrent + privateKey + publicKey));
            return BitConverter.ToString(bytes).Replace("-","").ToLower();
        }
    }
}
