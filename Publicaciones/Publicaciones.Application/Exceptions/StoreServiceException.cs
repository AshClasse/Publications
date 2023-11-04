using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
    public class StoreServiceException : Exception
    {
        public StoreServiceException(string message) : base(message) { }
    }
}
