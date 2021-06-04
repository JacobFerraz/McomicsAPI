using System.Collections.Generic;

namespace MComics.Business.ResponseModels
{
    public class GenericResult
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<ItemResult> items { get; set; }
        public int returned { get; set; }
    }

}
