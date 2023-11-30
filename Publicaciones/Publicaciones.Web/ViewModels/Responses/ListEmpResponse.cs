using Publicaciones.Web.ViewModels.Models;

namespace Publicaciones.Web.ViewModels.Responses
{
    public class ListEmpResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<GetEmpViewModel> Data  { get; set; }
    }
}
