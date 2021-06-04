using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Core.InterfacesGenerics
{
    public interface IApplication<T,U> : IDisposable where T : IAggregateRoot where U : IFilterAggregate
    {
        Task<IEnumerable<T>> BuscarLista(U parameter);
        Task<T> BuscarEntidade(U parameter);
    }
}
