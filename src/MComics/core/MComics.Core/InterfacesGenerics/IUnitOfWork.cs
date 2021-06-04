using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Core.InterfacesGenerics
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
