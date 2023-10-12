using System.Collections.Generic;
using System.Linq;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
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
    }
}