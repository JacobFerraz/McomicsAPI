using MComics.Business.Adapter.Interfaces;
using MComics.Business.Models;
using MComics.Business.ResponseModels;
using MComics.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Adapter
{
    public class PersonagemAdapter : IPersonagemAdapter
    {
        public Personagem CreateEntity(ResultPersonagem responseModel)
        {
            return new Personagem()
            {
                Id = responseModel.id,
                Nome = responseModel.name,
                Descricao = responseModel.description,
                Imagem = responseModel.thumbnail.path,
                Eventos = AdapterService.MontaListaEntidades(responseModel.events),
                Quadrinhos = AdapterService.MontaListaEntidades(responseModel.comics)
            };
        }
    }
}
