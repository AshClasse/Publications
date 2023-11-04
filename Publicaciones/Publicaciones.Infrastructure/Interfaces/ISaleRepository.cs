using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System.Collections.Generic;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Sale GetSaleByID(int storeID, string ordNum, int titleID);
        public List<SaleStoreTitleModel> GetSalesStoresAndTitles();
        SaleStoreTitleModel GetSaleStoreTitle(int storeID, string ordNum, int titleID);
        List<SaleStoreTitleModel> GetSalesByStoreID(int storeID);
        List<SaleStoreTitleModel> GetSalesStores();
        SaleStoreTitleModel GetSaleStore(int ID);
        List<SaleStoreTitleModel> GetSaleByOrdNum(string ordNum);
        List<SaleStoreTitleModel> GetSalesByTitleID(int titleID);
        List<SaleStoreTitleModel> GetSalesTitles();
        SaleStoreTitleModel GetSaleTitle(int ID);
    }
}
