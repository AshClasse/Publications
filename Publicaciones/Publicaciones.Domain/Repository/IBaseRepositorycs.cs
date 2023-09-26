using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
 
    public interface IBaseRepository<Tentity> where Tentity : class
    {
        void Save(Tentity entity);
        void Update(Tentity entity);
        void Remove(Tentity entity);
        List<Tentity> GetEntities();
        Tentity GetEntityByID(int Id);
    }
}

