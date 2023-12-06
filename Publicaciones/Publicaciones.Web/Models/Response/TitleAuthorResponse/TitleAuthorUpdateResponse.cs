using Publicaciones.Application.Dtos.TitleAuthor;

namespace Publicaciones.Web.Models.Response.TitleAuthorResponse
{
    public class TitleAuthorUpdateResponse : BaseResponse<TitleAuthorDtoUpdate>
    {
    }
   /* public class TitleAuthorEditViewResponse
    {
        public int au_ID { get; set; }
        public int title_ID { get; set; }
        public int au_Ord { get; set; }
        public int royaltyPer { get; set; }
        public int idModifiedUser { get; set; } = 1;
        public DateTime modifiedDate { get; set; } = DateTime.Now;
    }*/
}
