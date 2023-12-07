using Publicaciones.Application.Dtos;
using Publicaciones.Application.Dtos.Base;
using Publicaciones.Web.Models.Responses;

namespace Publicaciones.Web
{
    public interface IApiService
    {
        public BaseResponse<T> GetDataFromApi<T>(string apiUrl);
        public T PostDataToApi<T>(string apiUrl, DtoBase data);
    }
}
