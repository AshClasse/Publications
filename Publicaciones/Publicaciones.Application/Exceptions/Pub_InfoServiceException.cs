using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
	public class Pub_InfoServiceException : Exception
	{
		public Pub_InfoServiceException(string message) : base(message) { }
	}
}
