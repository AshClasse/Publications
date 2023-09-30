using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IAuthorsRepository
    {
        void Save(Authors author);
        void Update(Authors author);
        void Remove(Authors author);
        List<Authors> GetAuthors();
        Authors GetAuthor(string Author_ID);
    }
}

