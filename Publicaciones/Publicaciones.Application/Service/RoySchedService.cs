using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Response;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class RoySchedService : IRoySchedService
	{
		private readonly IRoySchedRepository _roySchedRepository;
		private readonly ILogger<RoySchedService> _logger;
		private readonly IConfiguration configuration;

		public RoySchedService(IRoySchedRepository roySchedRepository, 
								ILogger<RoySchedService> logger,
								IConfiguration configuration)
		{
			_roySchedRepository = roySchedRepository;
			_logger = logger;
			this.configuration = configuration;
		}

		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{

				result.Data = this._roySchedRepository.GetRoySchedsTitles();
				result.Message = "Regalías obtenidas exitosamente";

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while getting royalty scheds: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();

			try
			{

				result.Data = this._roySchedRepository.RoySchedTitle(id);
				result.Message = "Regalía obtenida exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while getting royalty sched: {ex.Message}";
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
				result.Message = "Regalía borrada exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while removing royalty sched: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Save(RoySchedDtoAdd dtoAdd)
		{
			RoySchedResponse result = new RoySchedResponse();

			try
			{
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
				result.Message = "Regalía guardada exitosamente";
				result.RoySched_ID = roySched.RoySched_ID;

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while saving royalty sched: {ex.Message}";
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
				result.Message = "Regalía actualizada exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while updating royalty sched: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Exists(int roySchedId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var exists = this._roySchedRepository.Exists(rs => rs.RoySched_ID == roySchedId);
				result.Data = exists;

				if (!exists)
				{
					result.Success = false;
					result.Message = $"{configuration["ValidationMessage:roySchedIdExists"]}";
				}

			}
			catch (Exception ex)
			{
				result.Success = false;
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult IRoySchedService.ExistsInTitles(int titleId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var exists = this._roySchedRepository.ExistsInTitles(titleId);
				result.Data = exists;

				if (!exists)
				{
					result.Success = false;
					result.Message = $"{configuration["ValidationMessage:titleIdExists"]}";
				}

			}
			catch (Exception ex)
			{
				result.Success = false;
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult IRoySchedService.GetRoySchedsByRoyalty(int royalty)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var roySched = this._roySchedRepository.GetRoySchedsByRoyalty(royalty)
					.Select(rs => new RoySchedDtoGetAll()
					{
						RoySched_ID = rs.RoySched_ID,
						Title_ID = rs.Title_ID,
						Royalty = rs.Royalty,
						HiRange= rs.HiRange,
						LoRange = rs.Royalty
					}).ToList();

				result.Data = roySched;
				result.Message = "Regalías obtenidas exitosamente";

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while getting royalty scheds: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult IRoySchedService.GetRoySchedsByTitleID(int titleId)
		{
			ServiceResult result = new ServiceResult();
			try
			{

				result.Data = this._roySchedRepository.GetRoySchedsByTitleID(titleId);
				result.Message = "Regalías obtenidas exitosamente";

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"The following error occurred while getting royalty scheds: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}
	}
}
