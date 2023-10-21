using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interface;

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
            base.Update(entity);
            context.SaveChanges();
        }
    }
}