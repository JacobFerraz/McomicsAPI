using MComics.Business.Models;
using MComics.Business.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MComics.Core.Services
{
    public static class AdapterService
    {
        public static List<EntityPartial> MontaListaEntidades(GenericResult result)
        {
            var listaEntidades = new List<EntityPartial>();

            if (result.items != null && result.items.Count > 0)
            {
                foreach (var entity in result.items)
                {
                    listaEntidades.Add(new EntityPartial(entity.name, ObterId(entity.resourceURI)));
                }
            }

            return listaEntidades;
        }

        private static int ObterId(string url)
        {
            if (string.IsNullOrEmpty(url)) return 0;

            var subUrl = url.Substring(url.IndexOf("public"));
            return int.Parse(new Regex(@"[^\d]").Replace(subUrl,""));
        }
    }
}
