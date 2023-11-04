using System.Collections.Generic;
using System.Linq;
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
            return context.employee.Where(cd => cd.PubID == PubID 
                                                && !cd.Deleted).ToList();
        }

        public List<Employee> GetEmployeeByJobID(int JobID)
        {
            return context.employee.Where(cd => cd.JobID == JobID 
                                                && !cd.Deleted).ToList();
        }

        public override void Save(Employee entity)
        {
            base.Save(entity);
            context.SaveChanges();
        }

        public override void Update(Employee entity)
        {
            var EmployeetoUpdate = base.GetEntityByID(entity.EmpID);

            EmployeetoUpdate.EmpID = entity.EmpID;
            EmployeetoUpdate.FirstName = entity.FirstName;
            EmployeetoUpdate.LastName = entity.LastName;
            EmployeetoUpdate.Minit = entity.Minit;
            EmployeetoUpdate.HireDate = entity.HireDate;
            EmployeetoUpdate.Joblvl = entity.Joblvl;
            EmployeetoUpdate.PubID = entity.PubID;
            EmployeetoUpdate.JobID = entity.JobID;
            EmployeetoUpdate.ModifiedDate = entity.ModifiedDate;
            EmployeetoUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.employee.Update(EmployeetoUpdate);
            context.SaveChanges();
        }

        public override void Remove(Employee entity)
        {
            var EmployeeRemove = base.GetEntityByID(entity.EmpID);

            EmployeeRemove.EmpID = entity.EmpID;
            EmployeeRemove.Deleted = true;
            EmployeeRemove.DeletedDate = entity.DeletedDate;
            EmployeeRemove.DeletedUser = entity.DeletedUser;

            context.employee.Update(EmployeeRemove);
            context.SaveChanges();
        }
    }
}
