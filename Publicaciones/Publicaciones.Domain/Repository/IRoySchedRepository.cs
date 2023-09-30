using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IRoySchedRepository
    {
        void Save(RoySched roysched);
        void Update(RoySched roysched);
        void Remove(RoySched roysched);
        List<RoySched> GetRoyScheds();
        RoySched GetRoySched(string ID);
    }
}
