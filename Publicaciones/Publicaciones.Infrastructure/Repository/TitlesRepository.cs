using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
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

        public Titles GetTitle(int ID)
        {
            return context.Titles.Find(ID);
        }

        public Titles GetTitle(string ID)
        {
            return context.Titles.Find(ID);
        }
        public List<Titles> GetTitles()
        {
            return context.Titles.ToList();
        }

        public void Remove(Titles titles)
        {
            context.Titles.Remove(titles);
        }

        public void Save(Titles titles)
        {
            context.Titles.Add(titles);
        }

        public void Update(Titles titles)
        {
            context.Titles.Update(titles);
        }
    }
}
