using Publicaciones.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Dtos.Authors
{
	public class AuthorsDtoRemove : DtoBase
    {
		public bool Deleted { get; set; }
	}
}
