using MComics.Business.Application.Interfaces;
using MComics.Business.Services.Interfaces;
using MComics.Data.Mapping.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioApplication(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public async Task<string> BuscarImagemUsuario(Guid id)
        {
            return await _usuarioService.BuscarImagemUsuario(id);
        }

        public async Task<ImageUser> InserirImagemUsuario(string url, Guid id)
        {
            return await _usuarioService.InserirImagemUsuario(url, id);
        }
    }
}
