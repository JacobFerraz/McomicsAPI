using MComics.Business.Models;
using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.Services.Interfaces
{
    public interface IEventoService : IService<Evento, FilterBase>
    {
    }
}
