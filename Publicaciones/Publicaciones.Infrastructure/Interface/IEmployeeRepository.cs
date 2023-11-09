using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Model;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        EmployeeRelationModel GetEmployeeByJob (int JobID);
        List <EmployeeRelationModel> GetEmployeeJob();
        List<Employee> GetEmployeeByJobID(int JobID);
        List<Employee> GetEmployeeByPubID(int PubID);
    }
}
