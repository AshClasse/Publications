using Microsoft.EntityFrameworkCore.Query;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interface;
using Publicaciones.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly PublicacionesContext context;

        public PublicacionesContext Context => context;

        public EmployeeRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Employee> GetEmployeeByPubID(int PubID)
        {
            return Context.employee.Where(cd => cd.PubID == PubID 
                                                && !cd.Deleted).ToList();
        }

        public List<Employee> GetEmployeeByJobID(int JobID)
        {
            return Context.employee.Where(cd => cd.JobID == JobID 
                                                && !cd.Deleted).ToList();
        }

        public override void Save(Employee entity)
        {
            base.Save(entity);
            Context.SaveChanges();
        }

        public override void Update(Employee entity)
        {
            var EmployeetoUpdate = base.GetEntityByID(entity.EmpID);

            EmployeetoUpdate.EmpID = entity.EmpID;
            EmployeetoUpdate.FirstName = entity.FirstName;
            EmployeetoUpdate.LastName = entity.LastName;
            EmployeetoUpdate.HireDate = entity.HireDate;
            EmployeetoUpdate.Joblvl = entity.Joblvl;
            EmployeetoUpdate.PubID = entity.PubID;
            EmployeetoUpdate.JobID = entity.JobID;
            EmployeetoUpdate.ModifiedDate = entity.ModifiedDate;
            EmployeetoUpdate.IDModifiedUser = entity.IDModifiedUser;

            Context.employee.Update(EmployeetoUpdate);
            Context.SaveChanges();
        }

        public override void Remove(Employee entity)
        {
            var EmployeeRemove = base.GetEntityByID(entity.EmpID);

            EmployeeRemove.EmpID = entity.EmpID;
            EmployeeRemove.Deleted = true;
            EmployeeRemove.DeletedDate = entity.DeletedDate;
            EmployeeRemove.DeletedUser = entity.DeletedUser;

            Context.employee.Update(EmployeeRemove);
            Context.SaveChanges();
        }

        public override List<Employee> GetEntities()
        {
            return base.GetEntities().Where(emp => !emp.Deleted)
                                     .OrderByDescending(emp => emp.CreationDate).ToList();
        }

        EmployeeRelationModel IEmployeeRepository.GetEmployeeinfobyID(int ID)
        {
            return GetEmployeeinfo().SingleOrDefault(emp => emp.EmpID == ID);
        }

        public List<EmployeeRelationModel> GetEmployeeinfo()
        {
            var employees = (from E in GetEntities()
                             join J in context.jobs on E.JobID equals J.JobID
                             join P in context.publishers on E.PubID equals P.PubID
                             where !E.Deleted
                             orderby E.CreationDate ascending
                             select new EmployeeRelationModel()
                             {
                                 EmpID = E.EmpID,
                                 JobID = E.JobID,
                                 PubID = E.PubID,
                                 FirstName = E.FirstName,
                                 LastName = E.LastName,
                                 HireDate = E.HireDate,
                                 Joblvl = E.Joblvl,
                                 PubName = P.PubName,
                                 Country = P.Country,
                                 City = P.City,
                                 State = P.State,
                                 JobDescription = J.JobDescription,
                                 CreationDate = J.CreationDate,

                             }).ToList();
            return employees;
        }
      
    }
}
