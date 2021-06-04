
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
    public class PersonagemController : MainController
    {
        private readonly IPersonagemApplication _personagemApplication;
        public PersonagemController(IPersonagemApplication personagemApplication)
        {
            _personagemApplication = personagemApplication;
        }

        [HttpGet("BuscarPersonagem{Id}")]
        public async Task<IActionResult> BuscarPersonagem(int Id)
        {
            var filtro = new FilterBase(string.Empty, Id);
            var result = await _personagemApplication.BuscarEntidade(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        [HttpGet("BuscarListaPersonagens{pagina}")]
        public async Task<IActionResult> BuscarListaQuadrinhos(int pagina, string nome)
        {
            var filtro = new FilterBase(nome, 0,pagina);
            var result = await _personagemApplication.BuscarLista(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }
    }
}
