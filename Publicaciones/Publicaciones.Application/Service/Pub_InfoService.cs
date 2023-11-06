using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Response;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class Pub_InfoService : IPub_InfoService
	{
		private readonly IPub_InfoRepository _pub_info_repository;
		private readonly ILogger<Pub_InfoService> _logger;
		public Pub_InfoService(IPub_InfoRepository pub_InfoRepository, ILogger<Pub_InfoService> logger)
		{
			this._pub_info_repository = pub_InfoRepository;
			this._logger = logger;
		}
		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{
				var pubInfos = this._pub_info_repository.GetEntities().Select(pi => new Pub_InfoDtoGetAll()
				{
					PubID = pi.PubID,
					Logo = pi.Logo,
					Pr_Info = pi.Pr_Info,
					ChangeDate = pi.CreationDate,
					ChangeUser = pi.IDCreationUser
				});

				result.Data = pubInfos;
				result.Message = "PubInfos obtenidos exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo las informaciones de publicaciones: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();
			try
			{
				var pub_infos = this._pub_info_repository.GetEntityByID(id);

				Pub_InfoDtoGetAll pub_InfoDtoGetAll = new Pub_InfoDtoGetAll()
				{
					PubID = pub_infos.PubID,
					Logo = pub_infos.Logo,
					Pr_Info = pub_infos.Pr_Info,
					ChangeDate = pub_infos.CreationDate,
					ChangeUser = pub_infos.IDCreationUser
				};

				result.Data = pub_InfoDtoGetAll;
				result.Message = "PubInfo obtenido exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Remove(Pub_InfoDtoRemove dtoRemove)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				Pub_Info pub_Info = new Pub_Info()
				{
					PubID = dtoRemove.Id,
					Deleted = dtoRemove.Deleted,
					DeletedDate = dtoRemove.ChangeDate,
					IDDeletedUser = dtoRemove.ChangeUser
				};

				this._pub_info_repository.Remove(pub_Info);
				result.Message = "PubInfo borrado exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error borrando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Save(Pub_InfoDtoAdd dtoAdd)
		{
			Pub_InfoResponse result = new Pub_InfoResponse();

			try
			{
				Pub_Info pub_Info = new Pub_Info()
				{
					CreationDate = dtoAdd.ChangeDate,
					IDCreationUser = dtoAdd.ChangeUser,
					Logo = dtoAdd.Logo,
					Pr_Info = dtoAdd.Pr_Info
				};

				this._pub_info_repository.Save(pub_Info);
				result.Message = "PubInfo guardado exitosamente";
				result.PubInfo_Id = pub_Info.PubID;

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error guardando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Update(Pub_InfoDtoUpdate dtoUpdate)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				Pub_Info pub_Info = new Pub_Info()
				{
					ModifiedDate = dtoUpdate.ChangeDate,
					IDModifiedUser = dtoUpdate.ChangeUser,
					PubID = dtoUpdate.PubID,
					Logo = dtoUpdate.Logo,
					Pr_Info = dtoUpdate.Pr_Info
				};

				this._pub_info_repository.Update(pub_Info);
				result.Message = "PubInfo actualizado exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error actualizando la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}
	}
}
