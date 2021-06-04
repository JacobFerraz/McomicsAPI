
namespace MComics.Core.InterfacesGenerics
{
    public interface IAdapter<in T,out R> where T : IResponseModel where R : IAggregateRoot
    {
        R CreateEntity (T responseModel);
    }
}
