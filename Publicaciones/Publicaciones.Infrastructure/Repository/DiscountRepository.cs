using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
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

        public Discount GetEntityByID(int Id)
        {
            return this.context.Discounts.Find(Id);
        }

        public Discount GetEntityByID(string Id)
        {
            return this.context.Discounts.Find(Id);
        }

        public List<Discount> GetEntities()
        {
            return context.Discounts.ToList();
        }

        public void Remove(Discount entity)
        {
            this.context.Discounts.Remove(entity);
        }

        public void Save(Discount entity)
        {
            this.context.Discounts.Add(entity);
        }

        public void Update(Discount entity)
        {
            this.context.Discounts.Update(entity);
        }
    }
}