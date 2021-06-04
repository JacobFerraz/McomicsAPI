using MComics.Core.Entities;
using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Models
{
    public class Quadrinho : EntityBase,IAggregateRoot
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<string> Imagens { get; set; }
        public string Miniatura { get; set; }
        public List<EntityPartial> Criadores { get; set; }
        public List<EntityPartial> Personagens { get; set; }
        public List<EntityPartial> Eventos { get; set; }
        public int NumeroDaEdicao { get; set; }

        public Quadrinho(string titulo, string descricao, List<string> imagens, string miniatura, List<EntityPartial> criadores, int numeroDaEdicao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagens = imagens;
            Miniatura = miniatura;
            Criadores = criadores;
            NumeroDaEdicao = numeroDaEdicao;
        }
        public Quadrinho() { }
    }
}
