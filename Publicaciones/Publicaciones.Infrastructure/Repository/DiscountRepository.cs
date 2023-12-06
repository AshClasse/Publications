using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
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
        public override void Save(Discount entity)
        {
            context.Discounts.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Discount entity)
        {
            var discountToUpdate = base.GetEntityByID(entity.DiscountID);

            discountToUpdate.DiscountType = entity.DiscountType;
            discountToUpdate.StoreID = entity.StoreID;
            discountToUpdate.LowQty = entity.LowQty;
            discountToUpdate.HighQty = entity.HighQty;
            discountToUpdate.DiscountAmount = entity.DiscountAmount;
            discountToUpdate.ModifiedDate = entity.ModifiedDate;
            discountToUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.Update(discountToUpdate);
            context.SaveChanges();
        }

        public override void Remove(Discount entity)
        {
            var discountToRemove = base.GetEntityByID(entity.DiscountID);
            discountToRemove.DiscountID = entity.DiscountID;
            discountToRemove.Deleted = true;
            discountToRemove.DeletedDate = entity.DeletedDate;
            discountToRemove.IDDeletedUser = entity.IDDeletedUser;

            this.context.Discounts.Update(discountToRemove);
            this.context.SaveChanges();
        }

        public override List<Discount> GetEntities()
        {
            return this.context.Discounts.Where(d => !d.Deleted)
                                         .OrderByDescending(s => s.CreationDate)
                                         .ToList();

        }

        public DiscountStoreModel GetDiscountStore(int ID)
        {
            return this.GetDiscountsStores().SingleOrDefault(d => d.DiscountID == ID);
        }

        public List<DiscountStoreModel> GetDiscountsByStoreID(int storeID)
        {
            return this.GetDiscountsStores().Where(d => d.StoreID == storeID).ToList();
        }

        public List<DiscountStoreModel> GetDiscountsStores()
        {

            var discounts = (from di in this.GetEntities()
                           join st in this.context.Stores on di.StoreID equals st.StoreID
                           where !di.Deleted
                           select new DiscountStoreModel()
                           {
                               DiscountID = di.DiscountID,
                               DiscountType = di.DiscountType,
                               DiscountAmount = di.DiscountAmount,
                               LowQty = di.LowQty,
                               HighQty = di.HighQty,
                               StoreID = st.StoreID,
                               StoreName = st.StoreName,
                               CreationDate = di.CreationDate
                           }).ToList();


            return discounts;
        }

        public List<Discount> GetDiscountsByStore(int storeID)
        {
            return this.context.Discounts.Where(ds => ds.DiscountID == storeID
                                              && !ds.Deleted).ToList();
        }
    }
}