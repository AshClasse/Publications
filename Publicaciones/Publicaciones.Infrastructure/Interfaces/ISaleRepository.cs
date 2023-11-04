using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Sale GetSaleByID(int storeID, string ordNum, int titleID);
        List<SaleStoreModel> GetSalesByStoreID(int storeID);
        List<SaleStoreModel> GetSalesStores();
        SaleStoreModel GetSaleStore(int ID);
        List<SaleStoreModel> GetSaleByOrdNum(string ordNum);
        List<SaleTitleModel> GetSalesByTitleID(int titleID);
        List<SaleTitleModel> GetSalesTitles();
        SaleTitleModel GetSaleTitle(int ID);
    }
}
