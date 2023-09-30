using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly PublicacionesContext context;
        public AuthorsRepository(PublicacionesContext context)
        {
            this.context = context;
        }
        public List<Authors> GetEntities()
        {
            return context.Authors.ToList();
        }

        public Authors GetEntityByID(int Id)
        {
            return context.Authors.Find(Id);
        }

        public Authors GetEntityByID(string Id)
        {
            return context.Authors.Find(Id);
        }

        public void Remove(Authors entity)
        {
            context.Authors.Remove(entity);
        }

        public void Save(Authors entity)
        {
            context.Authors.Add(entity);
        }

        public void Update(Authors entity)
        {
            context.Authors.Update(entity);
        }


    }
}