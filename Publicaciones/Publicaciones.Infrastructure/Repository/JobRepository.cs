using System.Collections.Generic;
using System.Linq;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
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
            base.Update(entity);
            context.SaveChanges();
        }
    }
}
