using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitlesRepository : BaseRepository<Titles>, ITitlesRepository
    {
        private readonly PublicacionesContext context;
        public TitlesRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public List<Titles> GetTitlesByPrice(decimal price)
		{
			throw new NotImplementedException();
		}

		public List<Titles> GetTitlesByPublisher(int pubId)
		{
			throw new NotImplementedException();
		}

		public List<Titles> GetTitlesByType(string type)
		{
			throw new NotImplementedException();
		}
	}
}
