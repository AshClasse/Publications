using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        private readonly PublicacionesContext context;

        public DiscountRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }
        public List<Discount> GetDiscountsByStore(string storeID)
        {
            return this.context.Discounts.Where(sd => sd.StoreID == storeID
                                                && !sd.Deleted).ToList();
        }

        public override List<Discount> GetEntities()
        {
            return base.GetEntities().Where(d => !d.Deleted).ToList();
        }
    }
}