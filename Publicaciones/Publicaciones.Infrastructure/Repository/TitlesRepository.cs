using Publicaciones.Domain.Entities;
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
        public override List<Titles> GetEntities()
        {
            return base.GetEntities().Where(s => !s.Deleted).ToList();
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
            titlesToUpdate.Type = entity.Type;
            titlesToUpdate.PubID =  entity.PubID;
            titlesToUpdate.Price = entity.Price;
            titlesToUpdate.Advance = entity.Advance;
            titlesToUpdate.Royalty = entity.Royalty;
            titlesToUpdate.Ytd_Sales = entity.Ytd_Sales;
            titlesToUpdate.Notes = entity.Notes;
            titlesToUpdate.PubDate = entity.PubDate;
            titlesToUpdate.ModifiedDate = entity.ModifiedDate;
            titlesToUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.Titles.Update(titlesToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Titles entity)
        {
            var titlesToRemove = base.GetEntityByID(entity.Title_ID);
            titlesToRemove.Title_ID = entity.Title_ID;
            titlesToRemove.Deleted = entity.Deleted;
            titlesToRemove.DeletedDate = entity.DeletedDate;
            titlesToRemove.IDDeletedUser = entity.IDDeletedUser;

            context.Titles.Update(titlesToRemove);
            context.SaveChanges();
        }
    }
}
