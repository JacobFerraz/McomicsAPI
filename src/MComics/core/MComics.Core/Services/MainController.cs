using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MComics.Core.Services
{
    [ApiController]
    public class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidaOperacao())
            {
                return Ok(result);
            }
            return NotFound(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens" , Erros.ToArray() }
            }));
        }
        protected bool ValidaOperacao()
        {
            return !Erros.Any();
        }

        protected void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }

        protected void AdicionaErroBase()
        {
            this.AdicionarErro("Houve um erro durante a requisição");
        }

        protected void LimparErros()
        {
            Erros.Clear();
        }
    }
}
