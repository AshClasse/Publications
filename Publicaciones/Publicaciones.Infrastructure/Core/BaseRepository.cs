using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntityByID(int ID)
        {
            return this.entities.Find(ID);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
            this.context.SaveChanges();
        }
    }
}
