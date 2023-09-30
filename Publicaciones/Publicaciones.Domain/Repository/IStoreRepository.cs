using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IStoreRepository
    {
        void Save(Store sale);
        void Update(Store sale);
        void Remove(Store sale);
        List<Sale> GetStores();
        Sale GetStoreByID(int ID);

    }

}