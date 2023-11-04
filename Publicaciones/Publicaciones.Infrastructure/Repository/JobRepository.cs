using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interface;

namespace Publicaciones.Infrastructure.Repository
{
    public class JobRepository : BaseRepository<Jobs> , IJobsRepository
    {
        private readonly PublicacionesContext context;

        public JobRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public override void Save(Jobs entity)
        {
            base.Save(entity);
            context.SaveChanges();
        }

        public override void Update(Jobs entity)
        {
            var JobUpdate = base.GetEntityByID(entity.JobID);

            JobUpdate.JobID = entity.JobID;
            JobUpdate.JobDescription = entity.JobDescription;
            JobUpdate.Maxlvl = entity.Maxlvl;
            JobUpdate.Minlvl = entity.Minlvl;
            JobUpdate.ModifiedDate = entity.ModifiedDate;
            JobUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.jobs.Update(JobUpdate);
            context.SaveChanges();

        }

        public override void Remove(Jobs entity)
        {
            var JobRemove = base.GetEntityByID(entity.JobID);

            JobRemove.JobID = entity.JobID;
            JobRemove.Deleted = true;
            JobRemove.DeletedDate = entity.DeletedDate;
            JobRemove.DeletedUser = entity.DeletedUser;

            context.jobs.Update(JobRemove);
            context.SaveChanges();
        }
    }
}
