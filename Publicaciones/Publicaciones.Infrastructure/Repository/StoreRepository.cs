using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
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

        public override void Remove(Store entity)
        {
            var storeToRemove = base.GetEntityByID(entity.StoreID);
            storeToRemove.StoreID = entity.StoreID;
            storeToRemove.Deleted = true;
            storeToRemove.DeletedDate = entity.DeletedDate;
            storeToRemove.IDDeletedUser = entity.IDDeletedUser;

            this.context.Stores.Update(storeToRemove);
            this.context.SaveChanges();
        }
        public override List<Store> GetEntities()
        {
            return this.context.Stores.Where(s => !s.Deleted)
                                      .OrderByDescending(s => s.CreationDate)
                                      .ToList();
        }

        public List<StoreModel> GetStores()
        {
            var stores = this.context.Stores
                             .Where(s => !s.Deleted)
                             .OrderByDescending(s => s.CreationDate)
                             .Select(s => new StoreModel
                                {
                                    StoreID = s.StoreID,
                                    StoreName = s.StoreName,
                                    StoreAddress = s.StoreAddress,
                                    Zip = s.Zip
                                })
                                .ToList();

            return stores;
        }

        public StoreModel GetStore(int storeID)
        {
            var stores = this.GetStores();
            return stores.Find(s => s.StoreID == storeID);
        }
    }
}