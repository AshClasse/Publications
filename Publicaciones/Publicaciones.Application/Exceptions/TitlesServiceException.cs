using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Exceptions
{
	public class TitlesServiceException : Exception
	{
		public TitlesServiceException(string message) : base(message) { }
	}
}
