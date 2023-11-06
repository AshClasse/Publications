using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitlesRepository : BaseRepository<Titles>, ITitlesRepository
    {
        private readonly PublicacionesContext context;
        public TitlesRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public List<Titles> GetTitlesByPrice(decimal price)
		{
			return this.context.Titles.Where(t => t.Price == price).ToList();
		}

		public List<Titles> GetTitlesByPublisher(int pubId)
		{
			return this.context.Titles.Where(t => t.PubID == pubId).ToList();
		}

		public List<Titles> GetTitlesByType(string type)
		{
			return this.context.Titles.Where(t =>t.Type == type).ToList();
		}
		public override List<Titles> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted)
				.OrderByDescending(st => st.CreationDate)
										.ToList();
		}

		public override void Save(Titles entity)
		{
			context.Titles.Add(entity);
			context.SaveChanges();
		}

		public override void Update(Titles entity)
		{
			var titlesToUpdate = base.GetEntityByID(entity.Title_ID);

			titlesToUpdate.Title = entity.Title;
			titlesToUpdate.Royalty = entity.Royalty;
			titlesToUpdate.Type = entity.Type;
			titlesToUpdate.Ytd_Sales = entity.Ytd_Sales;
			titlesToUpdate.Price = entity.Price;	
			titlesToUpdate.Advance = entity.Advance;
			titlesToUpdate.PubID = entity.PubID;
			titlesToUpdate.Notes = entity.Notes;
			titlesToUpdate.PubDate = entity.PubDate;
			titlesToUpdate.ModifiedDate = entity.ModifiedDate;
			titlesToUpdate.IDModifiedUser = entity.IDModifiedUser;

			context.Titles.Update(titlesToUpdate);
			context.SaveChanges();
		}

		public override void Remove(Titles entity)
		{
			var titleToRemove = base.GetEntityByID(entity.Title_ID);

			titleToRemove.Title_ID = entity.Title_ID;
			titleToRemove.Deleted = entity.Deleted;
			titleToRemove.DeletedDate = entity.DeletedDate;
			titleToRemove.IDDeletedUser = entity.IDDeletedUser;

			this.context.Titles.Update(titleToRemove);
			this.context.SaveChanges();

		}
	}
}
