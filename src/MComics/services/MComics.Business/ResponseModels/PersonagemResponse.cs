using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.ResponseModels
{
    public class PersonagemResponse 
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<ResultPersonagem> results { get; set; }
    }
    public class ResultPersonagem : IResponseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ImagesResult thumbnail { get; set; }
        public string resourceURI { get; set; }
        public GenericResult comics { get; set; }
        public GenericResult events { get; set; }
    }
}
