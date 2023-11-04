namespace Publicaciones.Application.Core
{
    public interface IBaseService <DToUpdate, DToAdd ,DToRemove>
    {
        ServiceResult GetAll();
        ServiceResult GetByID(int ID);
        ServiceResult Save(DToAdd dtoadd);
        ServiceResult Remove(DToRemove dtoremove);
        ServiceResult Update(DToUpdate dtoupdate);
    }
}
