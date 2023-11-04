using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Application.Core
{
	internal interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove>
	{
		ServiceResult GetAll();
		ServiceResult GetById(int Id);
		ServiceResult Save();
  		ServiceResult Update(TDtoIpdate dtoUpdate);
    		ServiceResult Remove(TDtoRemove dtoRemove);
	}
}
