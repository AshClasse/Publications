using Publicaciones.Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Response
{
    internal class AuthorResponse : ServiceResult
    {
        public int Au_ID { get; set; }
    }
}
