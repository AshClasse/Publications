using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Contract
{
	public interface IPub_InfoService : IBaseServices<Pub_InfoDtoAdd, Pub_InfoDtoUpdate, Pub_InfoDtoRemove>
	{
	}
}
