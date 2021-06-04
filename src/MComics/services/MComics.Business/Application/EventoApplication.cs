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
    public class EventoApplication : IEventoApplication
    {
        private readonly IEventoService _eventoService;
        public EventoApplication(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public async Task<Evento> BuscarEntidade(FilterBase parameter)
        {
            return await _eventoService.BuscarEntidade(parameter);
        }

        public async Task<IEnumerable<Evento>> BuscarLista(FilterBase parameter)
        {
            return await _eventoService.BuscarLista(parameter);
        }

        public void Dispose()
        {
            _eventoService.Dispose();
        }
    }
}
