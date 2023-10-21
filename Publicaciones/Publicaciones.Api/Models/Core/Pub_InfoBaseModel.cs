namespace Publicaciones.Api.Models.Core
{
    public class Pub_InfoBaseModel : BaseModel
    {
        public string PubID { get; set; }
        public byte[]? Logo { get; set; }
        public string? Pr_Info { get; set; }
    }
}
