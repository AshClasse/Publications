using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
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

		public bool ExistsInPublishers(int pubId)
		{
			return this.context.Set<Publisher>().Any(p => p.PubID == pubId);
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
			bool pubInfoExists = base.Exists(pi => pi.PubInfoID == entity.PubID);

			if (pubInfoExists)
			{
				var pubInfoToUpdate = base.GetEntityByID(entity.PubInfoID);

				pubInfoToUpdate.PubID = entity.PubID;
				pubInfoToUpdate.Pr_Info = entity.Pr_Info;
				pubInfoToUpdate.Logo = entity.Logo;
				pubInfoToUpdate.ModifiedDate = entity.ModifiedDate;
				pubInfoToUpdate.IDModifiedUser = entity.IDModifiedUser;

				context.Pub_Info.Update(pubInfoToUpdate);
				context.SaveChanges();
			}
			
		}

		public override void Remove(Pub_Info entity)
		{
			var pubInfoToRemove = base.GetEntityByID(entity.PubInfoID);

			pubInfoToRemove.PubInfoID = entity.PubInfoID;
			pubInfoToRemove.Deleted = entity.Deleted;
			pubInfoToRemove.DeletedDate = entity.DeletedDate;
			pubInfoToRemove.IDDeletedUser = entity.IDDeletedUser;

			this.context.Pub_Info.Update(pubInfoToRemove);
			this.context.SaveChanges();

		}

		public List<Pub_InfoPublisherModel> GetPub_InfosByPublisherID(int pubId)
		{
			return this.GetPublishersInfos().Where(pi => pi.PubID == pubId).ToList();
		}

		public List<Pub_InfoPublisherModel> GetPublishersInfos()
		{
			var pubInfos = (from pi in this.GetEntities()
							join pub in this.context.Publisher on pi.PubID equals pub.PubID
							where !pi.Deleted
							select new Pub_InfoPublisherModel()
							{
								Pub_InfoID = pi.PubInfoID,
								PubID = pub.PubID,
								PubName = pub.PubName,
								PrInfo = pi.Pr_Info,
								City = pub.City,
								State = pub.State,
								CreationDate = pi.CreationDate
							}).ToList();

			return pubInfos;
		}

		public Pub_InfoPublisherModel GetInfoPublisherByID(int pubInfoId)
		{
			return this.GetPublishersInfos().SingleOrDefault(pi => pi.Pub_InfoID == pubInfoId);
		}
	}
}
