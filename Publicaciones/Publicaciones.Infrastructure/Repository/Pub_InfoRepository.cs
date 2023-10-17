using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;

namespace Publicaciones.Infrastructure.Repository
{
    public class Pub_InfoRepository : BaseRepository<Pub_Info>, IPub_InfoRepository
    {
        private readonly PublicacionesContext context;
        public Pub_InfoRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

        public override void Save(Pub_Info entity)
        {
            this.context.SaveChanges();
        }
    }
}
