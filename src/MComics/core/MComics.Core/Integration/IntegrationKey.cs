using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Core.Integration
{
    public class IntegrationKey : IIntegrationKey
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public IntegrationKey(string publicKey, string privateKey)
        {
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;
        }
    }
}
