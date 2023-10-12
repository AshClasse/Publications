using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Publicaciones.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PublicacionesContext context;

        private DbSet<TEntity> entities;

        public BaseRepository(PublicacionesContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public TEntity GetEntityByID(object ID)
        {
            return this.entities.Find(ID);
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public void Save(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }
    }
}
