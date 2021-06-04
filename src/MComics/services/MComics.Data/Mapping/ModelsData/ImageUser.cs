using MComics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Data.Mapping.ModelsData
{
    public class ImageUser : EntityBaseDomain
    {
        public string URL { get; set; }

        public ImageUser(string uRL,Guid id)
        {
            URL = uRL;
            Id = id;
        }
        public ImageUser()
        {
        }
    }
}
