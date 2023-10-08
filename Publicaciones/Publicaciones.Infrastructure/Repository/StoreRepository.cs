using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        private readonly PublicacionesContext context;

        public StoreRepository(PublicacionesContext context) : base(context) 
        {
            this.context = context;
        }

        public override List<Store> GetEntities()
        {
            return base.GetEntities().Where(s => !s.Deleted).ToList();
        }
    }
}