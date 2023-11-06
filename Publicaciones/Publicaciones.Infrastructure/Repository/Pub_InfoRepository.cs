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
			return base.GetEntities().Where(s => !s.Deleted)
				.OrderByDescending(st => st.CreationDate)
										.ToList();
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

		public override void Remove(Pub_Info entity)
		{
			var pubInfoToRemove = base.GetEntityByID(entity.PubID);

			pubInfoToRemove.PubID = entity.PubID;
			pubInfoToRemove.Deleted = entity.Deleted;
			pubInfoToRemove.DeletedDate = entity.DeletedDate;
			pubInfoToRemove.IDDeletedUser = entity.IDDeletedUser;

			this.context.Pub_Info.Update(pubInfoToRemove);
			this.context.SaveChanges();

		}
	}
}
