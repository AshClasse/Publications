using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private readonly PublicacionesContext context;

        public SaleRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public Sale GetSaleByID(string storeID, string ordNum, string titleID)
        {
            return context.Sales.Find(storeID, ordNum, titleID);
        }

        public List<Sale> GetSaleByOrdNum(string ordNum)
        {
            return this.context.Sales.Where(so => so.OrdNum == ordNum
                                            && !so.Deleted).ToList();
        }

        public List<Sale> GetSaleByStore(string storeID)
        {
            return this.context.Sales.Where(ss => ss.StoreID == storeID
                                            && !ss.Deleted).ToList();
        }

        public List<Sale> GetSaleByTitle(string titleID)
        {
            return this.context.Sales.Where(st => st.TitleID == titleID
                                            && !st.Deleted).ToList();
        }

        public override List<Sale> GetEntities()
        {
            return base.GetEntities().Where(s => !s.Deleted).ToList();
        }
    }
}

