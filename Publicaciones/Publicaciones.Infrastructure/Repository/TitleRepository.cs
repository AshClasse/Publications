using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitleRepository : BaseRepository<Title>, ITitleRepository
    {
        private readonly PublicacionesContext context;

        public TitleRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Title> GetTitleByPublisher(int pubID)
        {
            return this.context.Titles.Where(t => t.PubID == pubID).ToList();
        }

        public override void Save(Title entity)
        {
            context.Titles.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Title entity)
        {
            var titleToUpdate = base.GetEntityByID(entity.TitleID);

            titleToUpdate.TitleName = entity.TitleName;
            titleToUpdate.Type = entity.Type;
            titleToUpdate.PubID = entity.PubID;
            titleToUpdate.Price = entity.Price;
            titleToUpdate.Advance = entity.Advance;
            titleToUpdate.Royalty = entity.Royalty;
            titleToUpdate.YtdSales = entity.YtdSales;
            titleToUpdate.Notes = entity.Notes;
            titleToUpdate.PubDate = entity.PubDate;

            context.Update(titleToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Title entity)
        {
            var titleToRemove = base.GetEntityByID(entity.TitleID);
            titleToRemove.TitleID = entity.TitleID;
            titleToRemove.Deleted = true;
            titleToRemove.DeletedDate = entity.DeletedDate;
            titleToRemove.IDDeletedUser = entity.IDDeletedUser;

            this.context.Titles.Update(titleToRemove);
            this.context.SaveChanges();
        }

        public override List<Title> GetEntities()
        {
            return this.context.Titles.Where(d => !d.Deleted)
                                         .OrderByDescending(s => s.CreationDate)
                                         .ToList();

        }
    }
}
