using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
 
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetEntityByID(int ID);
        TEntity GetEntityByID(string ID);
    }
}

