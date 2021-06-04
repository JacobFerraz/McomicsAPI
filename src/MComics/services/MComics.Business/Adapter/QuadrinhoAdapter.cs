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
    public class QuadrinhoAdapter : IQuadrinhoAdapter
    {
        public Quadrinho CreateEntity(ResultQuadrinho responseModel)
        {
            return new Quadrinho()
            {
                Id = responseModel.id,
                Titulo = responseModel.title,
                Descricao = responseModel.description,
                Miniatura = responseModel.thumbnail.path,
                NumeroDaEdicao = (int)responseModel.issueNumber,
                Imagens = responseModel.images.Select(img => img.path).ToList(),
                Personagens = AdapterService.MontaListaEntidades(responseModel.characters),
                Eventos = AdapterService.MontaListaEntidades(responseModel.events),
            };
        }
    }
}
