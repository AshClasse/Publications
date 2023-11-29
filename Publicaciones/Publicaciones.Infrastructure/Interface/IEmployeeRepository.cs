using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Model;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        EmployeeRelationModel GetEmployeeinfobyID (int ID);
        List <EmployeeRelationModel> GetEmployeeinfo();
        List<Employee> GetEmployeeByPubID(int PubID);
        List<Employee> GetEmployeeByJobID(int JobID);
    }
}
