using Publicaciones.Application.DTO.BasesDto;
using System.Data;

namespace Publicaciones.Application.DTO.Publishers
{
    public class PublisherDtoRemove : DtoBase
    {
        public int PubID { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
