using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        List<Discount> GetDiscountsByStore(int storeID);
    }
}
