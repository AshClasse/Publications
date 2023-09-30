using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface ITitleAuthorRepository
    {
        void Save(TitleAuthor titleAuthor);
        void Update(TitleAuthor titleAuthor);
        void Remove(TitleAuthor titleAuthor);
        List<TitleAuthor> GetTitleAuthors();
        Authors GetTitleAuthor(string TitleAuthor_ID);
    }
}
