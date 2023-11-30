using Publicaciones.Web.ViewModels.Models;

namespace Publicaciones.Web.ViewModels.Responses
{
    public class DeleteEmpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public DeleteEmpViewModel Data { get; set; }
    }
}
