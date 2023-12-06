using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
    public class AuthorServiceException : Exception
    {
        public AuthorServiceException(string message) : base(message) {}   
    }
}
