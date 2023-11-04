using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Sale;

namespace Publicaciones.Application.Contract
{
    public interface ISaleService : IBaseServices<SaleDtoAdd, SaleDtoUpdate, SaleDtoRemove>
    {
        ServiceResult GetSaleByID(int storeID, string ordNum, int titleID);
    }
}
