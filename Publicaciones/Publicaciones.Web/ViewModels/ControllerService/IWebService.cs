using Publicaciones.Web.Responses.Core;

namespace Publicaciones.Web.ViewModels.ControllerService
{
    public interface IWebService
    {
        public BaseResponse<T> GetData<T>(string URL);
        public T PostData <T>(string URL, object model);
    }
}
