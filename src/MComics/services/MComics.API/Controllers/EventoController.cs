using MComics.Business.Application.Interfaces;
using MComics.Business.Models;
using MComics.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MComics.API.Controllers
{
    [Route("api/personagens")]
    public class EventoController : MainController
    {
        private readonly IEventoApplication _eventoApplication;
        public EventoController(IEventoApplication eventoApplication)
        {
            _eventoApplication = eventoApplication;
        }

        [HttpGet("BuscarEvento{Id}")]
        public async Task<IActionResult> BuscarEvento(int Id)
        {
            var filtro = new FilterBase(string.Empty,Id);
            var result = await _eventoApplication.BuscarEntidade(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        [HttpGet("BuscarListaEventos{pagina}")]
        public async Task<IActionResult> BuscarListaQuadrinhos(int pagina,string nome)
        {
            var filtro = new FilterBase(nome, 0,pagina);
            var result = await _eventoApplication.BuscarLista(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }
    }
}
