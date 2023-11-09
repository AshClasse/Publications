using System;

namespace Publicaciones.Application.Exeptions
{
    public class PublisherServiceException : Exception
    {
        public PublisherServiceException(string message) : base(message) { }
    }
}
