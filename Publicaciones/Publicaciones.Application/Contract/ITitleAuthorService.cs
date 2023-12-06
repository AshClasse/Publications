using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.TitleAuthor;

namespace Publicaciones.Application.Contract
{
    public interface ITitleAuthorService : IBaseService<TitleAuthorDtoAdd, TitleAuthorDtoUpdate, TitleAuthorDtoRemove>
    {
        ServiceResult GetTitleAuthorById(int title_ID, int author_ID);
        ServiceResult GetTitleAuthorByAuthorOrder(int authorOrd);
        ServiceResult GetTitleAuthorByRoyalty(int royalty);
        ServiceResult GetTitleAuthorByTitle(int title);
        ServiceResult GetTitleByAu_ID(int au_ID);
        ServiceResult ExistInTitles(int title);
        ServiceResult ExistInAuthor(int author);
    }
}
