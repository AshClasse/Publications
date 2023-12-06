using Publicaciones.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Response
{
    public class TitleAuthorRespose : ServiceResult
    {
        public int AuthorId { get; set; }
        public int TitleId { get; set; }
    }
}
