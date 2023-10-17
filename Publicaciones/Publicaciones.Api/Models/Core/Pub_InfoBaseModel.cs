namespace Publicaciones.Api.Models.Core
{
    public abstract class Pub_InfoBaseModel
    {
        public string PubID { get; set; }
        public byte[]? Logo { get; set; }
        public string? Pr_Info { get; set; }
    }
}
