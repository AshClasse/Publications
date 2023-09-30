using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface ITitlesRepository
    {
        void Save(Titles title);
        void Update(Titles title);
        void Remove(Titles title);
        List<Titles> GetTitles();
        Titles GetTitle(string Title_ID);
    }
}
