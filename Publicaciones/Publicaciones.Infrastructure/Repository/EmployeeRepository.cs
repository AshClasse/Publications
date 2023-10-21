using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interface;

namespace Publicaciones.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly PublicacionesContext context;

        public EmployeeRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Employee> GetEmployeeByPubID(int PubID)
        {
            return this.context.employee.Where(cd => cd.PubID == PubID 
                                                && !cd.Deleted).ToList();
        }

        public List<Employee> GetEmployeeByJobID(int JobID)
        {
            return this.context.employee.Where(cd => cd.JobID == JobID 
                                                && !cd.Deleted).ToList();
        }

        public override void Save(Employee entity)
        {
            base.Save(entity);
            context.SaveChanges();
        }

        public override void Update(Employee entity)
        {
            base.Update(entity);
            context.SaveChanges();
        }

    }
}
