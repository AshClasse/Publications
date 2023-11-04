using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Core
{
	public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoRemove>
	{
		ServicesResult GetAll();
		ServicesResult GetByID(int id);
		ServicesResult Save(TDtoAdd dtoAdd);
		ServicesResult Update(TDtoUpdate dtoUpdate);
		ServicesResult Remove(TDtoRemove dtoRemove);
	}
}

