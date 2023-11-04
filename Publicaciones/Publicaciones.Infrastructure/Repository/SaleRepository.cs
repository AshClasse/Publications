using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
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

        public override void Remove(Sale entity)
        {
            var saleToRemove = GetSaleByID(entity.StoreID, entity.OrdNum, entity.TitleID);
            saleToRemove.StoreID = entity.StoreID;
            saleToRemove.Deleted = true;
            saleToRemove.DeletedDate = entity.DeletedDate;
            saleToRemove.IDDeletedUser = entity.IDDeletedUser;

            this.context.Sales.Update(saleToRemove);
            this.context.SaveChanges();
        }

        public override List<Sale> GetEntities()
        {
            return this.context.Sales.Where(s => !s.Deleted)
                                     .OrderByDescending(s => s.CreationDate)
                                     .ToList();
        }

        public List<SaleStoreModel> GetSalesByStoreID(int storeID)
        {
            return this.GetSalesStores().Where(s => s.StoreID == storeID).ToList();
        }

        public List<SaleStoreModel> GetSalesStores()
        {
            var sales = (from sa in this.GetEntities()
                             join st in this.context.Stores on sa.StoreID equals st.StoreID
                             where !sa.Deleted
                             select new SaleStoreModel()
                             {
                                 StoreID = st.StoreID,
                                 OrdNum = sa.OrdNum,
                                 TitleID = sa.TitleID,
                                 StoreName = st.StoreName,
                                 OrdDate = sa.OrdDate,
                                 Qty = sa.Qty,
                                 Payterms = sa.Payterms,
                                 CreationDate = sa.CreationDate
                             }).ToList();

            return sales;
        }

        public SaleStoreModel GetSaleStore(int ID)
        {
            return this.GetSalesStores().SingleOrDefault(s => s.StoreID == ID);
        }

        public List<SaleTitleModel> GetSalesByTitleID(int titleID)
        {
            return this.GetSalesTitles().Where(s => s.TitleID == titleID).ToList();
        }

        public List<SaleTitleModel> GetSalesTitles()
        {
            var sales = (from sa in this.GetEntities()
                         join t in this.context.Titles on sa.TitleID equals t.TitleID
                         where !sa.Deleted
                         select new SaleTitleModel()
                         {
                             TitleID = t.TitleID,
                             TitleName = t.TitleName,
                             Price = t.Price,
                             Advance = t.Advance,
                             Royalty = t.Royalty,
                             YtdSales = t.YtdSales,
                             OrdDate = sa.OrdDate,
                             CreationDate = sa.CreationDate
                             
                         }).ToList();

            return sales;
        }

        public SaleTitleModel GetSaleTitle(int ID)
        {
            return this.GetSalesTitles().SingleOrDefault(s => s.TitleID == ID);
        }

        public List<SaleStoreModel> GetSaleByOrdNum(string ordNum)
        {
            var sales = this.context.Sales
                        .Where(s => s.OrdNum == ordNum)
                        .Select(s => new SaleStoreModel
                        {
                              StoreID = s.StoreID,
                              OrdNum = s.OrdNum,
                              TitleID = s.TitleID,
                              Qty = s.Qty
                        })
                        .ToList();

            return sales;
        }
    }
}

