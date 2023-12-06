using Publicaciones.Domain.Entities;
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
    public class TitleAuthorRepository : BaseRepository<TitleAuthor>, ITitleAuthorRepository
    {
        private readonly PublicacionesContext context;
        
        public TitleAuthorRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public bool ExistsInAuthors(int authorID)
		{
			return this.context.Set<Authors>().Any(au => au.Au_ID == authorID);
		}

        public bool ExistsInTitles(int titleID)
        {
            return this.context.Set<Titles>().Any(ti => ti.Title_ID == titleID);
        }

        public List<TitleAuthor> GetTitleAuthorByAuthor(int authorID)
		{
			return this.context.TitleAuthor.Where(ta => ta.Au_ID == authorID).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByAuthorOrder(int authorOrd)
		{
			return this.context.TitleAuthor.Where(ta => ta.Au_Ord == authorOrd).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByRoyalty(int royalty)
		{
			return this.context.TitleAuthor.Where(ta => ta.RoyaltyPer == royalty).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByTitle(int titleID)
		{
			return this.context.TitleAuthor.Where(ta => ta.Title_ID == titleID).ToList();
		}
		public override List<TitleAuthor> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted).ToList();
		}
		public override void Save(TitleAuthor entity)
		{
			context.TitleAuthor.Add(entity);
			context.SaveChanges();
		}
		public override void Update(TitleAuthor entity)
		{
			var titleAuthorToUpdate = base.GetEntityByID(entity.Title_ID, entity.Au_ID);

            titleAuthorToUpdate.Au_Ord = entity.Au_Ord;
			titleAuthorToUpdate.RoyaltyPer = entity.RoyaltyPer;
			titleAuthorToUpdate.ModifiedDate = entity.ModifiedDate;
			titleAuthorToUpdate.IDModifiedUser = entity.IDModifiedUser;

			context.TitleAuthor.Update(titleAuthorToUpdate);
			context.SaveChanges();
		}

        public override void Remove(TitleAuthor entity)
        {
            var titleAuthorToUpdate = base.GetEntityByID(entity.Title_ID, entity.Au_ID);
			titleAuthorToUpdate.Au_ID = entity.Au_ID;
			titleAuthorToUpdate.Title_ID = entity.Title_ID;
			titleAuthorToUpdate.Deleted = entity.Deleted;
			titleAuthorToUpdate.IDDeletedUser = entity.IDDeletedUser;
			titleAuthorToUpdate.DeletedDate = entity.DeletedDate;

            context.TitleAuthor.Update(titleAuthorToUpdate);
            context.SaveChanges();
        }

        public List<AuthorsTitleAuthorsTitlesModel> GetTitlesByAu_ID(int authorID)
        {
            var titles = (from ta in context.TitleAuthor
                          join t in context.Titles on ta.Title_ID equals t.Title_ID
                          join au in context.Authors on ta.Au_ID equals au.Au_ID
                          where ta.Au_ID == authorID && !ta.Deleted
                          select new AuthorsTitleAuthorsTitlesModel
                          {
                              Au_ID = ta.Au_ID,
                              Title_ID = ta.Title_ID,
                              Au_LName = au.Au_LName,
                              Au_FName = au.Au_FName,
                              Title = t.Title,
                              Price = t.Price,
                              PubDate = t.PubDate
                          }).ToList();
            return titles;
        }

        public List<AuthorsTitleAuthorsTitlesModel> GetExtendedData()
        {
            var result = (from ta in this.GetEntities()
                          join ti in this.context.Titles on ta.Title_ID equals ti.Title_ID
                          join au in this.context.Authors on ta.Au_ID equals au.Au_ID
                          where !ta.Deleted
                          select new AuthorsTitleAuthorsTitlesModel()
                          {
                              Au_ID = ta.Au_ID, 
                              Au_FName = au.Au_FName,
                              Au_LName = au.Au_LName,
                              Title_ID = ta.Title_ID,
                              Title = ti.Title,
                              Price = ti.Price,
                              City = au.City,
                              Type = ti.Type,
                              PubDate = ti.PubDate,
                              PubID = ti.PubID,
                              Advance = ti.Advance,
                              Royalty = ti.Royalty,
                              Ytd_Sales = ti.Ytd_Sales,
                              Au_Ord = (int)ta.Au_Ord,
                              RoyaltyPer = ta.RoyaltyPer
                          }).ToList();
            return result;
        }

        public List<AuthorsTitleAuthorsTitlesModel> GetExtendedData(int id)
        {
            var result = (from ta in this.GetEntities()
                          join ti in this.context.Titles on ta.Title_ID equals ti.Title_ID
                          join au in this.context.Authors on ta.Au_ID equals au.Au_ID
                          where !ta.Deleted && ta.Au_ID == id
                          select new AuthorsTitleAuthorsTitlesModel()
                          {
                              Au_ID = au.Au_ID,
                              Au_FName = au.Au_FName,
                              Au_LName = au.Au_LName,
                              Title_ID = ti.Title_ID,
                              Title = ti.Title,
                              Price = ti.Price,
                              City = au.City,
                              Type = ti.Type,
                              PubDate = ti.PubDate,
                              PubID = ti.PubID,
                              Advance = ti.Advance,
                              Royalty = ti.Royalty,
                              Ytd_Sales = ti.Ytd_Sales,
                          }).ToList();
            return result;
        }

    }
}