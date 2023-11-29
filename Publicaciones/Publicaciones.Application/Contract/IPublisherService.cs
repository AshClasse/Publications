using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Publishers;

namespace Publicaciones.Application.Contract
{
    public interface IPublisherService : IBaseService <PublisherDtoUpdate,PublisherDtoAdd,PublisherDtoRemove>
    {

    }
}
