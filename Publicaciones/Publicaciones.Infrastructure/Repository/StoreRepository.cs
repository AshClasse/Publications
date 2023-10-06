using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PublicacionesContext context;

        public StoreRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public Store GetStoreByID(string ID)
        {
            return this.context.Stores.Find(ID);
        }

        public List<Store> GetStores()
        {
            return this.context.Stores.Where(s => !s.Deleted).ToList();
        }

        public void Remove(Store store)
        {
            this.context.Stores.Remove(store);
        }

        public void Save(Store store)
        {
            this.context.Stores.Add(store);
        }

        public void Update(Store store)
        {
            this.context.Stores.Update(store);
        }
    }
}