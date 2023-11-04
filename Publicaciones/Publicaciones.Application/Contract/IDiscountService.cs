using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Discount;

namespace Publicaciones.Application.Contract
{
    public interface IDiscountService : IBaseServices<DiscountDtoAdd, DiscountDtoUpdate, DiscountDtoRemove>
    {
    }
}
