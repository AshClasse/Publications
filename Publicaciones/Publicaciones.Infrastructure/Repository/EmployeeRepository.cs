using System.Collections.Generic;
using System.Linq;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;

namespace Publicaciones.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PublicacionesContext context;

        public EmployeeRepository(PublicacionesContext context)
        {
            this.context = context;
        }
        public Employee GetEmployeeID(string ID)
        {
            return this.context.employee.Find(ID);
        }

        public List<Employee> GetEmployees()
        {
            return context.employee.ToList();
        }

        public void Remove(Employee employee)
        {
            this.context.Remove(employee);
        }

        public void Save(Employee employee)
        {
            this.context.Add(employee);
        }

        public void Update(Employee employee)
        {
            this.context.Update(employee);
        }
    }
}
