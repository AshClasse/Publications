using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Infrastructure.Interfaces;
using System;
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

		public ServicesResult GetAll()
		{
			ServicesResult result = new ServicesResult();
			try
			{
				var royScheds = this._roySchedRepository.GetEntities()
					.Select(rs => new RoySchedGetAll()
						{
							RoySched_ID = rs.RoySched_ID,
							Title_ID = rs.Title_ID,
							HiRange = rs.HiRange,
							LoRange = rs.LoRange,
							Royalty = rs.Royalty,
							ChangeDate = rs.CreationDate,
							ChangeUser = rs.IDCreationUser
						});

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo las regalías: {ex.Message}";
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
				result.Message = $"Ocurrió el siguiente error obteniendo la regalía: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServicesResult Remove(RoySchedDtoRemove dtoRemove)
		{
			throw new NotImplementedException();
		}

		public ServicesResult Save(RoySchedDtoAdd dtoAdd)
		{
			throw new NotImplementedException();
		}

		public ServicesResult Update(RoySchedDtoUpdate dtoUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
