using MComics.Business.Models;
using MComics.Business.Services.Interfaces;
using MComics.Data.Mapping.ModelsData;
using MComics.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> BuscarImagemUsuario(Guid id)
        {
            return  await _usuarioRepository.BuscarImagemUsuario(id);
        }

        public async Task<ImageUser> InserirImagemUsuario(string url,Guid id)
        {
            var result = await _usuarioRepository.InserirImagemUsuario(url, id);

            await _usuarioRepository.UnitOfWork.Commit();

            return result;
        }
    }
}
