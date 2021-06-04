using MComics.Core.InterfacesGenerics;
using MComics.Data.DbContexts;
using MComics.Data.Mapping.ModelsData;
using MComics.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MComics.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public async Task<string> BuscarImagemUsuario(Guid id)
        {
            var result = await _context.UserImages.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            return result != null ? result.URL : string.Empty;
        }

        public async Task<ImageUser> InserirImagemUsuario(string url,Guid id)
        {
            var entity = new ImageUser(url, id);

            if (!string.IsNullOrEmpty(await this.BuscarImagemUsuario(id)))
            {
               return  _context.Update(entity).Entity;
            }

            var result = await _context.UserImages.AddAsync(entity);

            return result.Entity;
        }

        public void Dispose()
        {
            this._context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
