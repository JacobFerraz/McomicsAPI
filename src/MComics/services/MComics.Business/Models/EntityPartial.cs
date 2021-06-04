using MComics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Models
{
    public class EntityPartial : EntityBase 
    {
        public string Nome { get; set; }

        public EntityPartial(string nome, int id)
        {
            Nome = nome;
            this.Id = id;
        }
    }
}
