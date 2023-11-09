using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;
using Publicaciones.Application.Validations.IBaseValidations;

namespace Publicaciones.Application.Validations.ContractValidations
{
    public interface IjobsValidations : IValidationsServices<JobsDtoBase, JobsDtoUpdate, JobsDtoAdd, JobDtoRemove>
    {

    }
}
