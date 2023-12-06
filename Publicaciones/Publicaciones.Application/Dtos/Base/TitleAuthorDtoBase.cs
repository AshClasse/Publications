using Publicaciones.Application.Dtos.Base;

namespace Publicaciones.Application.Dtos.TitleAuthor
{
    public class TitleAuthorDtoBase : DtoBase
    {
        public int Au_ID { get; set; }
        public int Title_ID { get; set; }
        public int? Au_Ord { get; set; }
        public int? RoyaltyPer { get; set; }
    }
}
