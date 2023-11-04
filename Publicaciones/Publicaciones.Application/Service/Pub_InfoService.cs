using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class Pub_InfoService : IPub_InfoService
	{
		private readonly IPub_InfoRepository _pub_info_repository;
		private readonly ILogger _logger;
		public Pub_InfoService(IPub_InfoRepository pub_InfoRepository, ILogger logger)
		{
			this._pub_info_repository = pub_InfoRepository;
			this._logger = logger;
		}
		public ServicesResult GetAll()
		{
			ServicesResult result = new ServicesResult();
			try
			{
				var pubInfos = this._pub_info_repository.GetEntities().Select(pi => new Pub_InfoGetAll()
				{
					PubID = pi.PubID,
					Logo = pi.Logo,
					Pr_Info = pi.Pr_Info,
					ChangeDate = pi.CreationDate,
					ChangeUser = pi.IDCreationUser

				});
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo las informaciones de publicaciones: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServicesResult GetByID(int id)
		{
			ServicesResult result = new ServicesResult();
			try
			{
			
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo la información de publicación: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServicesResult Remove(Pub_InfoDtoRemove dtoRemove)
		{
			throw new NotImplementedException();
		}

		public ServicesResult Save(Pub_InfoDtoAdd dtoAdd)
		{
			throw new NotImplementedException();
		}

		public ServicesResult Update(Pub_InfoDtoUpdate dtoUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
