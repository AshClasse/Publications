
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class TitlesService : ITitlesService
	{
		private readonly ILogger _logger;
		private readonly ITitlesRepository _titlesRepository;
		public TitlesService(ITitlesRepository titlesRepository, 
			ILogger<TitlesService> logger) 
		{
			this._titlesRepository = titlesRepository;
			this._logger = logger;
		}
		public ServicesResult GetAll()
		{
			ServicesResult result = new ServicesResult();
			try
			{
				var titles = this._titlesRepository.GetEntities()
					.Select(tt => new TitlesGetAll()
						{
							Title_ID = tt.Title_ID,
							Title = tt.Title,
							PubID = tt.PubID,
							Royalty = tt.Royalty,
							Advance = tt.Advance,
							Price = tt.Price,
							Notes = tt.Notes,
							PubDate = tt.PubDate,
							Ytd_Sales = tt.Ytd_Sales,
							Type = tt.Type,
							ChangeDate = tt.CreationDate,
							ChangeUser = tt.IDCreationUser
						});
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo los títulos: {ex.Message}";
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
				result.Message = $"Ocurrió el siguiente error obteniendo el título: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServicesResult Remove(TitlesDtoRemove dtoRemove)
		{
			throw new System.NotImplementedException();
		}

		public ServicesResult Save(TitlesDtoAdd dtoAdd)
		{
			throw new System.NotImplementedException();
		}

		public ServicesResult Update(TitlesDtoUpdate dtoUpdate)
		{
			throw new System.NotImplementedException();
		}
	}
}
