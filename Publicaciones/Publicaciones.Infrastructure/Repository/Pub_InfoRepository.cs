using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Infrastructure.Repository
{
    public class Pub_InfoRepository : IPub_InfoRepository
    {
        private readonly PublicacionesContext context;

        public Pub_InfoRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public Pub_Info GetEntityByID(int Id)
        {
            return context.Pub_Infos.Find(Id);
        }

        public Pub_Info GetEntityByID(string Id)
        {
            return context.Pub_Infos.Find(Id);
        }

        public List<Pub_Info> GetEntities()
        {
            return context.Pub_Infos.ToList();
        }

        public void Remove(Pub_Info entity)
        {
            context.Pub_Infos.Remove(entity);
        }

        public void Save(Pub_Info entity)
        {
            context.Pub_Infos.Add(entity);
        }

        public void Update(Pub_Info entity)
        {
            context.Pub_Infos.Update(entity);
        }

    }
}
