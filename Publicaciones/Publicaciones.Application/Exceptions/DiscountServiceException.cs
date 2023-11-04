using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
    public class DiscountServiceException : Exception
    {
        public DiscountServiceException(string message) : base(message) {}

    }
}
