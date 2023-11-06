using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Core
{
	public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove>
	{
		ServiceResult GetAll();
		ServiceResult GetById(int Id);
		ServiceResult Save(TDtoAdd dtoAdd);
  		ServiceResult Update(TDtoUpdate dtoUpdate);
    	ServiceResult Remove(TDtoRemove dtoRemove);
	}
}
