using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Models
{
    public class FilterBase : IFilterAggregate
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get;}
        public FilterBase(string nome, int id, int pagina = 1)
        {
            Nome = nome;
            Id = id;
            QuantidadePorPagina = 24;
            Pagina = QuantidadePorPagina * (pagina - 1);
        }
    }
}
