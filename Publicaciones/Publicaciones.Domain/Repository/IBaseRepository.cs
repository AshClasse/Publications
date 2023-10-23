using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Publicaciones.Domain.Repository
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		void Save(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
		List<TEntity> GetEntities();
		TEntity GetEntityByID(int ID);
		TEntity GetEntityByID(int ID, int Id);
		List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
		bool Exists(Expression<Func<TEntity, bool>> filter);
	}
}

