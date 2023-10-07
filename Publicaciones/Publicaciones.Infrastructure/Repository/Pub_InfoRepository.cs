using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;

namespace Publicaciones.Infrastructure.Repository
{
    public class Pub_InfoRepository : IPub_InfoRepository
    {
        private readonly PublicacionesContext context;

        public Pub_InfoRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public Pub_Info GetPub_Info(string ID)
        {
            return this.context.Pub_Info.Find(ID);
        }

        public List<Pub_Info> GetPub_Infos()
        {
            return this.context.Pub_Info.ToList();
        }

        public void Remove(Pub_Info pub_info)
        {
            this.context.Pub_Info.Remove(pub_info);
        }

        public void Save(Pub_Info pub_info)
        {
            this.context.Pub_Info.Add(pub_info);
        }

        public void Update(Pub_Info pub_info)
        {
            this.context.Pub_Info.Update(pub_info);
        }
    }
}
