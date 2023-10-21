using Microsoft.OpenApi.Models;

namespace Publicaciones.Api.Models.Core
{
    public class EmployeeBaseModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Minit {  get; set; }
        public int JobID { get; set; }
        public int? Joblvl { get; set; }
        public int PubID { get; set; }
        public DateTime HireDate { get; set; }
    }
}
