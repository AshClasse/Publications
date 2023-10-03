using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
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

        public Sale GetSaleByID(string storId, string ordNum, string titleId)
        {
            return this.context.Sales.Find(storId, ordNum, titleId);
        }

        public List<Sale> GetSales()
        {
            return this.context.Sales.Where(s => !s.Deleted).ToList();
        }

        public void Remove(Sale sale)
        {
            this.context.Sales.Remove(sale);
        }

        public void Save(Sale sale)
        {
            this.context.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            this.context.Sales.Update(sale);
        }
    }
}

