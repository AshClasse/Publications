using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitlesRepository : ITitlesRepository
    {
        private readonly PublicacionesContext context;
        public TitlesRepository(PublicacionesContext context)
        {
            this.context = context;
        }
        public List<Titles> GetEntities()
        {
            return context.Titles.ToList();
        }

        public Titles GetEntityByID(int Id)
        {
            return context.Titles.Find(Id);
        }

        public Titles GetEntityByID(string Id)
        {
            return context.Titles.Find(Id);
        }

        public void Remove(Titles entity)
        {
            context.Titles.Remove(entity);
        }

        public void Save(Titles entity)
        {
            context.Titles.Add(entity);
        }

        public void Update(Titles entity)
        {
            context.Titles.Update(entity);
        }
    }
}
