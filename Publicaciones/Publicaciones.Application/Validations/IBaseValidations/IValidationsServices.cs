using Publicaciones.Application.Core;

namespace Publicaciones.Application.Validations.IBaseValidations
{
    public interface IValidationsServices<DtoBase, DtoUpdate, DtoAdd, DtoRemove>
    {
        ServiceResult CommonValidations(DtoBase dtobase);
        ServiceResult DtoUpdateValidations(DtoUpdate dtoupdate);
        ServiceResult DtoAddValidations(DtoAdd dtoupdate);
        ServiceResult DtoRemoveValidations(DtoRemove dtoremove);
    }
}