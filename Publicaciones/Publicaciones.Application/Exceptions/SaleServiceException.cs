using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
    public class SaleServiceException : Exception
    {
        public SaleServiceException(string message) : base(message) { }
    }
}
