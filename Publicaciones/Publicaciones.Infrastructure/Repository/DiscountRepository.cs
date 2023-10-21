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
        public List<Discount> GetDiscountsByStore(int storeID)
        {
            return this.context.Discounts.Where(sd => sd.StoreID == storeID
                                                && !sd.Deleted).ToList();
        }

        public override void Save(Discount entity)
        {
            context.Discounts.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Discount entity)
        {
            var discountToUpdate = base.GetEntityByID(entity.StoreID);

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
    }
}