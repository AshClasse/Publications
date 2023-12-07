using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
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
		public bool Exists(int titleID)
		{
			return base.Exists(tt => tt.Title_ID == titleID);
		}
		public bool ExistsInPublishers(int pubId)
		{
			return this.context.Set<Publisher>().Any(p => p.PubID == pubId);
		}
		public List<Titles> GetTitlesByPrice(decimal price)
		{
			return this.context.Titles.Where(t => t.Price == price).ToList();
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
			titleToRemove.Deleted = true;
			titleToRemove.DeletedDate = entity.DeletedDate;
			titleToRemove.IDDeletedUser = entity.IDDeletedUser;

			this.context.Titles.Update(titleToRemove);
			this.context.SaveChanges();

		}

		public List<TitlePublisherModel> GetTitlesByPublisherID(int pubId)
		{
			return this.GetTitlesPublishers().Where(tp => tp.PubID == pubId).ToList();
		}

		public List<TitlePublisherModel> GetTitlesPublishers()
		{
			var title = (from tt in this.GetEntities()
							join pub in this.context.Publisher on tt.PubID equals pub.PubID
							where !tt.Deleted
							select new TitlePublisherModel()
							{
								Title_ID = tt.Title_ID,
								Title = tt.Title,
								PubID = tt.PubID,
								PubName = pub.PubName,
								Type = tt.Type,
								PubDate = tt.PubDate,
								Notes = tt.Notes,
								Price = tt.Price,
								Royalty = tt.Royalty,
								CreationDate = tt.CreationDate
							}).ToList();

			return title;
		}

		public TitlePublisherModel TitlePublisher(int titleId)
		{
			return this.GetTitlesPublishers().SingleOrDefault(tp => tp.Title_ID == titleId);
		}
	}
}
