using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        List<Sale> GetSalesByStore(string storeID);
        List<Sale> GetSalesByTitle(string titleID);
        List<Sale> GetSalesByOrdNum(string ordNum);
    }
}
