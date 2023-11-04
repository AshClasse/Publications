namespace Publicaciones.Application.DTO.Employee
{
    public class EmployeeDtoRemove : EmployeeDtoBase
    {
        public bool Deleted { get; set; }
        public int EmpID { get; set; }
    }
}
