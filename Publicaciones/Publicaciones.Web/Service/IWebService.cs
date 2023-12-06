using Publicaciones.Application.Dtos;
using Publicaciones.Web.Models.Responses;

namespace Publicaciones.Web.Service
{
    public interface IWebService
    {
        public BaseResponse<T> GetDataFromApi<T>(string apiUrl);
        public T PostDataToApi<T>(string apiUrl, DtoBase data);
    }
}
