using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;

namespace Publicaciones.Application.Contract
{
    public interface IJobsService : IBaseService<JobsDtoUpdate, JobsDtoAdd, JobDtoRemove>
    {

    }
}
