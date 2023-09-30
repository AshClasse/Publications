using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly PublicacionesContext context;

        public SaleRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public Sale GetEntityByID(int Id)
        {
            return this.context.Sales.Find(Id);
        }

        public Sale GetEntityByID(string Id)
        {
            return this.context.Sales.Find(Id);
        }

        public List<Sale> GetEntities()
        {
            return context.Sales.ToList();
        }

        public void Remove(Sale entity)
        {
            this.context.Sales.Remove(entity);
        }

        public void Save(Sale entity)
        {
            this.context.Sales.Add(entity);
        }

        public void Update(Sale entity)
        {
            this.context.Sales.Update(entity);
        }
    }
}