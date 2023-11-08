using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
	public class RoySchedServiceException : Exception
	{
		public RoySchedServiceException(string message) : base(message) { }
	}
}
