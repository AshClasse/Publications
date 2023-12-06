using System;

namespace Publicaciones.Application.Exceptions
{
    public class TitleAuthorServiceException : Exception
    {
        public TitleAuthorServiceException(string message) : base(message) { }  
    }
}
