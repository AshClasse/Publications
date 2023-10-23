using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class AuthorsRepository : BaseRepository<Authors>, IAuthorsRepository
    {
        private readonly PublicacionesContext context;
        public AuthorsRepository(PublicacionesContext context) : base(context) 
        {
            this.context = context;
        }

		public override List<Authors> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted).ToList();
		}
		public List<Authors> GetAuthorsByCity(string city)
		{
			return this.context.Authors.Where(au => au.City == city).ToList();
		}

		public List<Authors> GetAuthorsByContract(int contract)
		{
			return this.context.Authors.Where(au => au.Contract == contract).ToList();
		}

		public List<Authors> GetAuthorsByState(string state)
		{
			return this.context.Authors.Where(au =>au.State == state).ToList();
		}
		public override void Save(Authors entity)
		{
			context.Authors.Add(entity);
			context.SaveChanges();
		}

		public override void Update(Authors entity)
		{
			var authorsToUpdate = base.GetEntityByID(entity.Au_ID);

			authorsToUpdate.Au_FName = entity.Au_FName;
			authorsToUpdate.Au_LName = entity.Au_LName;
			authorsToUpdate.Phone = entity.Phone;
			authorsToUpdate.Address = entity.Address;
			authorsToUpdate.City = entity.City;
			authorsToUpdate.Contract = entity.Contract;
			authorsToUpdate.State = entity.State;
			authorsToUpdate.Zip	= entity.Zip;

			context.Authors.Update(authorsToUpdate);
			context.SaveChanges();
		}
	}
}