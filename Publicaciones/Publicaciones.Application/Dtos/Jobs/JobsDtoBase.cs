using Publicaciones.Application.DTO.BasesDto;

namespace Publicaciones.Application.DTO.Jobs
{

    public class JobsDtoBase : DtoBase
    {
        public string JobDescription { get; set; }
        public byte Minlvl { get; set; }
        public byte Maxlvl { get; set; }

    }
}
