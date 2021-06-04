using MComics.Core.InterfacesGenerics;
using MComics.Data.Mapping.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Data.Repository.Interfaces
{
    public interface IUsuarioRepository : IDisposable
    {
        Task<ImageUser> InserirImagemUsuario(string url,Guid id);
        Task<string> BuscarImagemUsuario(Guid id);
        IUnitOfWork UnitOfWork { get; }
    }
}
