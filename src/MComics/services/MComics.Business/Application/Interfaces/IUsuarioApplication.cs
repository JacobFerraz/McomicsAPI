using MComics.Data.Mapping.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<ImageUser> InserirImagemUsuario(string url, Guid id);
        Task<string> BuscarImagemUsuario(Guid id);
    }
}
