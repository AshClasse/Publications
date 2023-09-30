using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
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

        public Store GetEntityByID(int Id)
        {
            return this.context.Stores.Find(Id);
        }

        public Store GetEntityByID(string Id)
        {
            return this.context.Stores.Find(Id);
        }

        public List<Store> GetEntities()
        {
            return context.Stores.ToList();
        }

        public void Remove(Store entity)
        {
            this.context.Stores.Remove(entity);
        }

        public void Save(Store entity)
        {
            this.context.Stores.Add(entity);
        }

        public void Update(Store entity)
        {
            this.context.Stores.Update(entity);
        }
    }
}