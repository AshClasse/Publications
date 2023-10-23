using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ITitleAuthorRepository : IBaseRepository<TitleAuthor>
    {
		bool ExistsInAuthors(int authorID);
		List<TitleAuthor> GetTitleAuthorByAuthor(int authorID);
        List<TitleAuthor> GetTitleAuthorByTitle(int titleID);
        List<TitleAuthor> GetTitleAuthorByAuthorOrder(int authorOrd);
        List<TitleAuthor> GetTitleAuthorByRoyalty(int royalty);
    }
}