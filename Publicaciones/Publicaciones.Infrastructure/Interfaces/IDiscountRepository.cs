using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        List<Discount> GetDiscountsByStore(int storeID);
    }
}
