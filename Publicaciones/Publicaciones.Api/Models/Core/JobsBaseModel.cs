namespace Publicaciones.Api.Models.Core
{
    public class JobsBaseModel : BaseModel
    {
        public string JobDescription { get; set; }
        public byte Minlvl { get; set; }
        public byte Maxlvl { get; set; }
    }
}
