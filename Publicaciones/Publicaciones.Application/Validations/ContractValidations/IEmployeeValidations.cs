using Publicaciones.Application.DTO.Employee;
using Publicaciones.Application.Validations.IBaseValidations;

namespace Publicaciones.Application.Validations.ContractValidations
{
    public interface IEmployeeValidations : IValidationsServices <EmployeeDtoBase, EmployeeDtoUpdate , EmployeeDtoAdd, EmployeeDtoRemove>
    {

    }
}
