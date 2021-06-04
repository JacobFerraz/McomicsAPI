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
    [Route("api/quadrinho")]
    public class QuadrinhoController : MainController
    {
        private readonly IQuadrinhoApplication _quadrinhoApplication;

        public QuadrinhoController(IQuadrinhoApplication quadrinhoApplication)
        {
            _quadrinhoApplication = quadrinhoApplication;
        }

        [HttpGet("BuscarQuadrinho{Id}")]
        public async Task<IActionResult> BuscarQuadrinho(int Id)
        {
            var filtro = new FilterBase(string.Empty, Id);
            var result = await _quadrinhoApplication.BuscarEntidade(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }

        [HttpGet("BuscarListaQuadrinhos{pagina}")]
        public async Task<IActionResult> BuscarListaQuadrinhos(int pagina,string nome)
        {
            var filtro = new FilterBase(nome, 0,pagina);
            var result = await _quadrinhoApplication.BuscarLista(filtro);

            if (result == null)
            {
                AdicionaErroBase();
                return CustomResponse();
            }

            return CustomResponse(result);
        }
    }
}
