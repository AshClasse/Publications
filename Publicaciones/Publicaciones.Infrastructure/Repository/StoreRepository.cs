using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        private readonly PublicacionesContext context;

        public StoreRepository(PublicacionesContext context) : base(context) 
        {
            this.context = context;
        }

        public override void Save(Store entity)
        {
            context.Stores.Add(entity);
            context.SaveChanges();
        }

        public override void Update(Store entity)
        {
            var storeToUpdate = base.GetEntityByID(entity.StoreID);

            storeToUpdate.StoreName = entity.StoreName;
            storeToUpdate.StoreAddress = entity.StoreAddress;
            storeToUpdate.StoreAddress = entity.StoreAddress;
            storeToUpdate.City = entity.City;
            storeToUpdate.State = entity.State;
            storeToUpdate.Zip = entity.Zip;
            storeToUpdate.ModifiedDate = entity.ModifiedDate;
            storeToUpdate.IDModifiedUser = entity.IDModifiedUser;

            context.Stores.Update(storeToUpdate);
            context.SaveChanges();
        }
    }
}