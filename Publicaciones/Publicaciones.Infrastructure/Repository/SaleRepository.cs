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

        public Sale GetSaleByID(int storeID, string ordNum, int titleID)
        {
            return context.Sales.Find(storeID, ordNum, titleID);
        }

        public List<Sale> GetSaleByOrdNum(string ordNum)
        {
            return this.context.Sales.Where(so => so.OrdNum == ordNum
                                            && !so.Deleted).ToList();
        }

        public List<Sale> GetSaleByStore(int storeID)
        {
            return this.context.Sales.Where(ss => ss.StoreID == storeID
                                            && !ss.Deleted).ToList();
        }

        public List<Sale> GetSaleByTitle(int titleID)
        {
            return this.context.Sales.Where(st => st.TitleID == titleID
                                            && !st.Deleted).ToList();
        }

        public override void Save(Sale entity)
        {
            context.Sales.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Sale entity)
        {
            var saleToUpdate = GetSaleByID(entity.StoreID, entity.OrdNum, entity.TitleID);

            saleToUpdate.StoreID = entity.StoreID;
            saleToUpdate.OrdNum = entity.OrdNum;
            saleToUpdate.TitleID = entity.TitleID;
            saleToUpdate.OrdDate = entity.OrdDate;
            saleToUpdate.Qty = entity.Qty;
            saleToUpdate.Payterms = entity.Payterms;
            saleToUpdate.ModifiedDate = entity.ModifiedDate;
            saleToUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.Sales.Update(saleToUpdate);
            context.SaveChanges();
        }
    }
}

