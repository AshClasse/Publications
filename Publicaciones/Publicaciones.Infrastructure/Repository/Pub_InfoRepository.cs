using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class Pub_InfoRepository : BaseRepository<Pub_Info>, IPub_InfoRepository
    {
        private readonly PublicacionesContext context;
        public Pub_InfoRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public override List<Pub_Info> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted).ToList();
		}

		public override void Save(Pub_Info entity)
		{
			context.Pub_Info.Add(entity);
			context.SaveChanges();
		}

		public override void Update(Pub_Info entity)
		{
			var pubInfoToUpdate = base.GetEntityByID(entity.PubID);

			pubInfoToUpdate.Pr_Info = entity.Pr_Info;
			pubInfoToUpdate.Logo = entity.Logo;
			pubInfoToUpdate.ModifiedDate = entity.ModifiedDate;
			pubInfoToUpdate.IDModifiedUser = entity.IDModifiedUser;

			context.Pub_Info.Update(pubInfoToUpdate);
			context.SaveChanges();
		}
	}
}
