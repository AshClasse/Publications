using Publicaciones.Web.ViewModels.Models;

namespace Publicaciones.Web.ViewModels.Responses
{
    public class UpdateEmpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UpdateEmpViewModel Data { get; set; }
    }
}
