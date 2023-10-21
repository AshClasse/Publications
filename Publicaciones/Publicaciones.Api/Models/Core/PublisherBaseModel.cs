namespace Publicaciones.Api.Models.Core
{
    public class PublisherBaseModel : BaseModel
    {
        public string PubName { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }

    }
}
