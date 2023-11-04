using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        List<DiscountStoreModel> GetDiscountsByStoreID(int storeID);
        List<DiscountStoreModel> GetDiscountsStores();
        DiscountStoreModel GetDiscountStore(int storeID);
    }
}
