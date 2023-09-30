using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Publicaciones.Domain.Entities;

namespace Publicaciones.Domain.Repository
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        List<Employee> GetEmployees();
        Employee GetEmployeeID(int ID);

    }
}
