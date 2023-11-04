using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Store;

namespace Publicaciones.Application.Contract
{
    public interface IStoreService : IBaseServices<StoreDtoAdd, StoreDtoUpdate, StoreDtoRemove>
    {
        
    }
}
