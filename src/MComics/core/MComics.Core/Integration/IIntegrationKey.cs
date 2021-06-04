using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Core.Integration
{
    public interface IIntegrationKey
    {
        string PublicKey { get; set; }
        string PrivateKey { get; set; }
    }
}
