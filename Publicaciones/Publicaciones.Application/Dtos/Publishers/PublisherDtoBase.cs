using Publicaciones.Application.DTO.BasesDto;

namespace Publicaciones.Application.DTO.Publishers
{
    public class PublisherDtoBase : DtoBase
    {
        public string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
