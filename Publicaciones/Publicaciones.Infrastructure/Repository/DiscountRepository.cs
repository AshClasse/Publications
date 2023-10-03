using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly PublicacionesContext context;

        public DiscountRepository(PublicacionesContext context)
        {
            this.context = context;
        }
        public List<Discount> GetDiscounts()
        {
            return this.context.Discounts.Where(d => !d.Deleted).ToList();
        }

        public void Remove(Discount discount)
        {
            this.context.Discounts.Remove(discount);
        }

        public void Save(Discount discount)
        {
            this.context.Discounts.Add(discount);
        }

        public void Update(Discount discount)
        {
            this.context.Discounts.Update(discount);
        }
    }
}