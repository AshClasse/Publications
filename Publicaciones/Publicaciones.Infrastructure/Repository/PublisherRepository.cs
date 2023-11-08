using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
	public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
	{
		private readonly PublicacionesContext _context;
		public PublisherRepository(PublicacionesContext context) : base(context)
		{
			_context = context;
		}
	}
}
