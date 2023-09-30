using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
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
        public List<RoySched> GetEntities()
        {
            return context.RoyScheds.ToList();
        }

        public RoySched GetEntityByID(int Id)
        {
            return context.RoyScheds.Find(Id);
        }

        public RoySched GetEntityByID(string Id)
        {
            return context.RoyScheds.Find(Id);
        }

        public void Remove(RoySched entity)
        {
            context.RoyScheds.Remove(entity);
        }

        public void Save(RoySched entity)
        {
            context.RoyScheds.Add(entity);
        }

        public void Update(RoySched entity)
        {
            context.RoyScheds.Update(entity);
        }
    }
}
