using MComics.Core.InterfacesGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComics.Business.ResponseModels
{
    public class EventoResponse
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public List<ResultEvento> results { get; set; }
    }
    public class ResultEvento : IResponseModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string resourceURI { get; set; }
        public ImagesResult thumbnail { get; set; }
        public GenericResult creators { get; set; }
        public GenericResult characters { get; set; }
        public GenericResult stories { get; set; }
        public GenericResult comics { get; set; }
        public GenericResult series { get; set; }
    }
}
