using Publicaciones.Domain.Core;

namespace Publicaciones.Domain.Entities
{
    public class Pub_Info : BaseEntity
    {
		public int PubInfoID { get; set; }
		public int PubID { get; set; }
        public byte[]? Logo { get; set; }
        public string? Pr_Info { get; set; }
    }
}
