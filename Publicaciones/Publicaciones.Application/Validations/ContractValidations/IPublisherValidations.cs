using Publicaciones.Application.DTO.Publishers;
using Publicaciones.Application.Validations.IBaseValidations;

namespace Publicaciones.Application.Validations.ContractValidations
{
    public interface IPublisherValidations : IValidationsServices <PublisherDtoBase , PublisherDtoUpdate , PublisherDtoAdd , PublisherDtoRemove>
    {

    }
}
