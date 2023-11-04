using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        List<Employee> GetEmployeeByPubID (int PubID);
        List<Employee> GetEmployeeByJobID(int JobID);
    }
}
