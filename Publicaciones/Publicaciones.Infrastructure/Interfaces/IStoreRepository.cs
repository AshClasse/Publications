using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        public List<StoreModel> GetStores();
        public StoreModel GetStore(int storeID);
    }
}
