using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class RoySchedRepository : IRoySchedRepository
    {
        private readonly PublicacionesContext context;
        public RoySchedRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public RoySched GetRoySched(int ID)
        {
            return context.RoySched.Find(ID);
        }

        public RoySched GetRoySched(string ID)
        {
            return context.RoySched.Find(ID);
        }
        public List<RoySched> GetRoyScheds()
        {
            return context.RoySched.ToList();
        }

        public void Remove(RoySched roySched)
        {
            context.RoySched.Remove(roySched);
        }

        public void Save(RoySched roySched)
        {
            context.RoySched.Add(roySched);
        }

        public void Update(RoySched roySched)
        {
            context.RoySched.Update(roySched);
        }
    }
}
