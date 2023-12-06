using Publicaciones.Application.Dtos.Base;
using System;

namespace Publicaciones.Application.Dtos.TitleAuthor
{
	public class TitleAuthorDtoRemove : DtoBase
    {
        public int Au_ID { get; set; }
        public int Title_ID { get; set; }
        public bool Deleted { get; set; }   
    }
}
