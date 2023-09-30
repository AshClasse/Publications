using System.Collections.Generic;
using System.Linq;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;

namespace Publicaciones.Infrastructure.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly PublicacionesContext context;

        public PublisherRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public Publisher GetPublisherID(string ID)
        {
            return this.context.Publishers.Find(ID);
        }

        public List<Publisher> GetPublishers()
        {
            return this.context.Publishers.ToList();
        }

        public void Remove(Publisher publisher)
        {
            this.context.Remove(publisher);
        }

        public void Save(Publisher publisher)
        {
            this.context.Add(publisher);
        }

        public void Update(Publisher publisher)
        {
            this.context.Update(publisher);
        }
    }
}

