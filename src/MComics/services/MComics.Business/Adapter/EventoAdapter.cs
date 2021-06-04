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
    public class EventoAdapter : IEventoAdapter
    {
        public Evento CreateEntity(ResultEvento responseModel)
        {
            return new Evento()
            {
                Id = responseModel.id,
                Titulo = responseModel.title,
                Descricao = responseModel.description,
                Imagem = responseModel.thumbnail.path,
                Quadrinhos = AdapterService.MontaListaEntidades(responseModel.comics),
                Personagens = AdapterService.MontaListaEntidades(responseModel.characters)
            };
        }
    }
}
