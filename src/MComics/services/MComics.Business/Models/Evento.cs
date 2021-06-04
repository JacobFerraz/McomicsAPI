using MComics.Core.Entities;
using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Models
{
    public class Evento : EntityBase, IAggregateRoot
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public List<EntityPartial> Quadrinhos { get; set; }
        public List<EntityPartial> Personagens { get; set; }

        public Evento(string titulo, string descricao, string imagem, List<EntityPartial> quadrinhos, List<EntityPartial> personagens)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Quadrinhos = quadrinhos;
            Personagens = personagens;
        }
        public Evento(){ }
    }
}
