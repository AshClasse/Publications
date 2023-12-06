using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ITitleAuthorRepository : IBaseRepository<TitleAuthor>
    {
		bool ExistsInAuthors(int authorID);
        bool ExistsInTitles(int titleId);
        List<TitleAuthor> GetTitleAuthorByAuthor(int authorID);
        List<TitleAuthor> GetTitleAuthorByTitle(int titleID);
        List<TitleAuthor> GetTitleAuthorByAuthorOrder(int authorOrd);
        List<TitleAuthor> GetTitleAuthorByRoyalty(int royalty);
        public List<AuthorsTitleAuthorsTitlesModel> GetExtendedData(int authorID);
        public List<AuthorsTitleAuthorsTitlesModel> GetExtendedData();
        List<AuthorsTitleAuthorsTitlesModel> GetTitlesByAu_ID(int authorID);
    }
}