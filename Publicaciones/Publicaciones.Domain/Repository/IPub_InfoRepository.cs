using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IPub_InfoRepository
    {
        void Save(Pub_Info pub_info);
        void Update(Pub_Info pub_info);
        void Remove(Pub_Info pub_info);
        List<Pub_Info> GetPub_Infos();
        Pub_Info GetPub_Info(string ID);
    }
}
