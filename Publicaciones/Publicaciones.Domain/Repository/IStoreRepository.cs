using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IStoreRepository
    {
        void Save(Store store);
        void Update(Store store);
        void Remove(Store store);
        List<Store> GetStores();
        Store GetStoreByID(string id);
    }

}