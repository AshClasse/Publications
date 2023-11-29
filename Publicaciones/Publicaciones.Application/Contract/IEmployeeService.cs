using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;

namespace Publicaciones.Application.Contract
{
    public interface IEmployeeService : IBaseService<EmployeeDtoUpdate,EmployeeDtoAdd,EmployeeDtoRemove>
    {

    }
}
