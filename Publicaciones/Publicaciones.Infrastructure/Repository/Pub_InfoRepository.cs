using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class Pub_InfoRepository : BaseRepository<Pub_Info>, IPub_InfoRepository
    {
        private readonly PublicacionesContext context;
        public Pub_InfoRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public override List<Pub_Info> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted).ToList();
		}
	}
}
