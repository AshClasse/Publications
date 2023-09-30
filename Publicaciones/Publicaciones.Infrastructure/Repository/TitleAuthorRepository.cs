using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitleAuthorRepository : ITitleAuthorRepository
    {
        private readonly PublicacionesContext context;
        public TitleAuthorRepository(PublicacionesContext context)
        {
            this.context = context;
        }
        public List<TitleAuthor> GetEntities()
        {
            return context.TitleAuthors.ToList();
        }

        public TitleAuthor GetEntityByID(int Id)
        {
            return context.TitleAuthors.Find(Id);
        }

        public TitleAuthor GetEntityByID(string Id)
        {
            return context.TitleAuthors.Find(Id);
        }

        public void Remove(TitleAuthor entity)
        {
            context.TitleAuthors.Remove(entity);
        }

        public void Save(TitleAuthor entity)
        {
            context.TitleAuthors.Add(entity);
        }

        public void Update(TitleAuthor entity)
        {
            context.TitleAuthors.Update(entity);
        }


    }
}