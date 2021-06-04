using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MComics.Core.Identidade
{
    public class AppSettings
    {
        public string Segredo { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string  Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
