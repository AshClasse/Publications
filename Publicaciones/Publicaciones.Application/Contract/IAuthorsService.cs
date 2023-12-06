
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Authors;

namespace Publicaciones.Application.Contract
{
	public interface IAuthorsService : IBaseService<AuthorsDtoAdd, AuthorsDtoUpdate, AuthorsDtoRemove>
    {
        ServiceResult GetById(int Id);
        ServiceResult GetAuthorsByCity(string city);
        ServiceResult GetAuthorsByState(string state);
        ServiceResult GetAuthorsByContract(int contract);
    }
}
