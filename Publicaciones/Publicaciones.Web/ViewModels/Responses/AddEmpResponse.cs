using Publicaciones.Web.ViewModels.Models;

namespace Publicaciones.Web.ViewModels.Responses
{
    public class AddEmpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public AddEmpViewModel Data { get; set; }
    }
}
