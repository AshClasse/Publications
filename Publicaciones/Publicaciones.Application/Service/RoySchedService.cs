using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class RoySchedService : IRoySchedService
	{
		private readonly IRoySchedRepository _roySchedRepository;
		private readonly ILogger _logger;

		public RoySchedService(IRoySchedRepository roySchedRepository, ILogger logger)
		{
			_roySchedRepository = roySchedRepository;
			_logger = logger;
		}

		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{
				var royScheds = this._roySchedRepository.GetEntities()
					.Select(rs => new RoySchedDtoGetAll()
						{
							RoySched_ID = rs.RoySched_ID,
							Title_ID = rs.Title_ID,
							HiRange = rs.HiRange,
							LoRange = rs.LoRange,
							Royalty = rs.Royalty,
							ChangeDate = rs.CreationDate,
							ChangeUser = rs.IDCreationUser
						});

				result.Data = royScheds;

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo las regalías: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var roySched = this._roySchedRepository.GetEntityByID(id);

				RoySchedDtoGetAll roySchedDtoGetAll = new RoySchedDtoGetAll()
				{
					RoySched_ID = roySched.RoySched_ID,
					Title_ID = roySched.Title_ID,
					HiRange = roySched.HiRange,
					LoRange = roySched.LoRange,
					Royalty = roySched.Royalty,
					ChangeDate = roySched.CreationDate,
					ChangeUser = roySched.IDCreationUser
				};

				result.Data = roySchedDtoGetAll;
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo la regalía: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		}

		public ServiceResult Remove(RoySchedDtoRemove dtoRemove)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				RoySched roySched = new RoySched()
				{
					RoySched_ID = dtoRemove.Id,
					Deleted = dtoRemove.Deleted,
					DeletedDate = dtoRemove.ChangeDate,
					IDDeletedUser = dtoRemove.ChangeUser
				};

				this._roySchedRepository.Remove(roySched);
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error borrando la regalía: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Save(RoySchedDtoAdd dtoAdd)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				//if (!_roySchedRepository.ExistsInTitles(dtoAdd.Title_ID))
				//{
					
				//}

				RoySched roySched = new RoySched()
				{
					Title_ID = dtoAdd.Title_ID,
					LoRange = dtoAdd.LoRange,
					HiRange = dtoAdd.HiRange,
					Royalty = dtoAdd.Royalty,
					CreationDate = dtoAdd.ChangeDate,
					IDCreationUser = dtoAdd.ChangeUser
				};

				this._roySchedRepository.Save(roySched);
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error guardando la regalía: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Update(RoySchedDtoUpdate dtoUpdate)
		{
			ServiceResult result = new ServiceResult();

			try
			{

				RoySched roySched = new RoySched()
				{
					RoySched_ID = dtoUpdate.RoySched_ID,
					Title_ID = dtoUpdate.Title_ID,
					LoRange = dtoUpdate.LoRange,
					HiRange = dtoUpdate.HiRange,
					Royalty = dtoUpdate.Royalty,
					ModifiedDate = dtoUpdate.ChangeDate,
					IDModifiedUser = dtoUpdate.ChangeUser
				};

				this._roySchedRepository.Update(roySched);
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error actualizando la regalía: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		//public ServiceResult ExistsInTitles(int titleId)
		//{
		//	ServiceResult result = new ServiceResult();

		//	try
		//	{

			
		//	}
		//	catch (Exception ex)
		//	{
		//		result.Success = false;
		//		result.Message = $"Ocurrió el siguiente error verificando si el título existe: {ex.Message}";
		//		this._logger.LogError(result.Message, ex.ToString());
		//	}

		//	return result;
		//}

		//public ServiceResult GetRoySchedsByRoyalty(int royalty)
		//{
		//	throw new NotImplementedException();
		//}

		//public ServiceResult GetRoySchedsByTitle(int titleId)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
