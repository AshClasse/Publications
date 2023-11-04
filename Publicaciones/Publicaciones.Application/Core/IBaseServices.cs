using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Core
{
	public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoRemove>
	{
		ServiceResult GetAll();
		ServiceResult GetByID(int id);
		ServiceResult Save(TDtoAdd dtoAdd);
		ServiceResult Update(TDtoUpdate dtoUpdate);
		ServiceResult Remove(TDtoRemove dtoRemove);
	}
}

