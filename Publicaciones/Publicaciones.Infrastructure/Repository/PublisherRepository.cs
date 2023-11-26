using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        private readonly PublicacionesContext context;

        public PublisherRepository(PublicacionesContext context) : base (context)
        {
            this.context = context;
        }

        public override void Save(Publisher entity)
        {
            base.Save(entity);
            context.SaveChanges();
        }

        public override void Update(Publisher entity)
        {
            var PublisherUpdate = base.GetEntityByID(entity.PubID);

            PublisherUpdate.PubID = entity.PubID;
            PublisherUpdate.PubName = entity.PubName;
            PublisherUpdate.City = entity.City;
            PublisherUpdate.Country = entity.Country; 
            PublisherUpdate.State = entity.State;
            PublisherUpdate.ModifiedDate = entity.ModifiedDate;
            PublisherUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.publishers.Update(PublisherUpdate);
            context.SaveChanges();
        }

        public override void Remove(Publisher entity)
        {
            var PublisherRemove = base.GetEntityByID(entity.PubID);

            PublisherRemove.PubID = entity.PubID;
            PublisherRemove.Deleted = true;
            PublisherRemove.DeletedDate = entity.DeletedDate;
            PublisherRemove.DeletedUser = entity.DeletedUser;

            context.publishers.Update(PublisherRemove);
            context.SaveChanges();
        }

        public override List<Publisher> GetEntities()
        {
            return base.GetEntities().Where(pub => !pub.Deleted).
                                            OrderByDescending(pub => pub.PubID).ToList();
        }
    }
}