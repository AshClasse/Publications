using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Sale GetSaleByID(string storeID, string ordNum, string titleID);
        List<Sale> GetSaleByStore(string storeID);
        List<Sale> GetSaleByTitle(string titleID);
        List<Sale> GetSaleByOrdNum(string ordNum);
    }
}
