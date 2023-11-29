using Publicaciones.Application.DTO.BasesDto;

namespace Publicaciones.Application.DTO.Employee
{
    public class EmployeeDtoRemove : DtoBase
    {
        public bool Deleted { get; set; } 
        public int EmpID { get; set; }
    }
}
