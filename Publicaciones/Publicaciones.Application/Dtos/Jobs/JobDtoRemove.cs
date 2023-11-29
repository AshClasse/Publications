using Publicaciones.Application.DTO.BasesDto;

namespace Publicaciones.Application.DTO.Jobs
{
    public class JobDtoRemove : DtoBase
    {
        public int JobID { get; set;}
        public bool Deleted { get; set; }
    }
}
