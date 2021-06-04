using MComics.Business.Application.Interfaces;
using MComics.Business.Models;
using MComics.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Application
{
    public class PersonagemApplication : IPersonagemApplication
    {
        private readonly IPersonagemService _personagemService;

        public PersonagemApplication(IPersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        public async Task<Personagem> BuscarEntidade(FilterBase parameter)
        {
            return await _personagemService.BuscarEntidade(parameter);
        }

        public async Task<IEnumerable<Personagem>> BuscarLista(FilterBase parameter)
        {
            return await _personagemService.BuscarLista(parameter);
        }

        public void Dispose()
        {
            this._personagemService.Dispose();
        }
    }
}
