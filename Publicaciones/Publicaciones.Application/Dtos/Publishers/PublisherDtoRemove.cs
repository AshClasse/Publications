namespace Publicaciones.Application.DTO.Publishers
{
    public class PublisherDtoRemove : PublisherDtoBase
    {
        public int PubID { get; set; }
        public bool Deleted { get; set; }
    }
}
