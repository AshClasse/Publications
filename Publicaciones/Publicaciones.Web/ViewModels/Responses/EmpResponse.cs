using Publicaciones.Web.ViewModels.Models;

namespace Publicaciones.Web.ViewModels.Responses
{
    public class EmpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public GetEmpViewModel Data { get; set; }
    }
}
