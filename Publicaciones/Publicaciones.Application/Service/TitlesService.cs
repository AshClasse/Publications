
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Response;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class TitlesService : ITitlesService
	{
		private readonly ILogger<TitlesService> _logger;
		private readonly ITitlesRepository _titlesRepository;
		public TitlesService(ITitlesRepository titlesRepository, 
			ILogger<TitlesService> logger) 
		{
			this._titlesRepository = titlesRepository;
			this._logger = logger;
		}
		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{
				var titles = this._titlesRepository.GetEntities()
					.Select(tt => new TitlesDtoGetAll()
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

				result.Data = titles;
				result.Message = "Títulos obtenidos exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo los títulos: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();
			try
			{
				var titles = this._titlesRepository.GetEntityByID(id);

				TitlesDtoGetAll titlesDtoGetAll = new TitlesDtoGetAll()
				{
					Title_ID = titles.Title_ID,
					Title = titles.Title,
					PubID = titles.PubID,
					Royalty = titles.Royalty,
					Advance = titles.Advance,
					Price = titles.Price,
					Notes = titles.Notes,
					PubDate = titles.PubDate,
					Ytd_Sales = titles.Ytd_Sales,
					Type = titles.Type,
					ChangeDate = titles.CreationDate,
					ChangeUser = titles.IDCreationUser
				};

				result.Data = titlesDtoGetAll;
				result.Message = "Título obtenido exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo el título: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Remove(TitlesDtoRemove dtoRemove)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				Titles titles = new Titles() 
				{ 
					Title_ID = dtoRemove.Id, 
					Deleted = dtoRemove.Deleted,
					DeletedDate = dtoRemove.ChangeDate,
					IDDeletedUser = dtoRemove.ChangeUser
				};

				this._titlesRepository.Remove(titles);
				result.Message = "Título borrado exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error borrando el título: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;

		}

		public ServiceResult Save(TitlesDtoAdd dtoAdd)
		{
			TitlesResponse result = new TitlesResponse();

			try
			{
				Titles titles = new Titles()
				{
					Title = dtoAdd.Title,
					Royalty = dtoAdd.Royalty,
					Type = dtoAdd.Type,
					Ytd_Sales = dtoAdd.Ytd_Sales,
					Price = dtoAdd.Price,
					Advance = dtoAdd.Advance,
					PubID = dtoAdd.PubID,
					Notes = dtoAdd.Notes,
					PubDate = dtoAdd.PubDate,
					CreationDate = dtoAdd.ChangeDate,
					IDCreationUser = dtoAdd.ChangeUser
				};

				this._titlesRepository.Save(titles);
				result.Message = "Título guardado exitosamente";
				result.Title_ID = titles.Title_ID;

			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error guardando el título: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		public ServiceResult Update(TitlesDtoUpdate dtoUpdate)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				Titles titles = new Titles()
				{
					Title_ID = dtoUpdate.Title_ID,
					Title = dtoUpdate.Title,
					Royalty = dtoUpdate.Royalty,
					Type = dtoUpdate.Type,
					Ytd_Sales = dtoUpdate.Ytd_Sales,
					Price = dtoUpdate.Price,
					Advance = dtoUpdate.Advance,
					PubID = dtoUpdate.PubID,
					Notes = dtoUpdate.Notes,
					PubDate = dtoUpdate.PubDate,
					ModifiedDate = dtoUpdate.ChangeDate,
					IDModifiedUser = dtoUpdate.ChangeUser
				};

				this._titlesRepository.Update(titles);
				result.Message = "Títulos actualizado exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error actualizando el título: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		}

		ServiceResult ITitlesService.GetTitlesByPrice(decimal price)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var titles = this._titlesRepository.GetTitlesByPrice(price)
					.Select(tt => new TitlesDtoGetAll()
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
					})
					.ToList();

				result.Data = titles;
				result.Message = "Títulos obtenidos exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo los títulos: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		}

		ServiceResult ITitlesService.GetTitlesByPublisher(int pubId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var titles = this._titlesRepository.GetTitlesByPublisher(pubId)
					.Select(tt => new TitlesDtoGetAll()
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
					})
					.ToList();

				result.Data = titles;
				result.Message = "Títulos obtenidos exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo los títulos: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		}

		ServiceResult ITitlesService.GetTitlesByType(string type)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var titles = this._titlesRepository.GetTitlesByType(type)
					.Select(tt => new TitlesDtoGetAll()
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
					})
					.ToList();

				result.Data = titles;
				result.Message = "Títulos obtenidos exitosamente";
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"Ocurrió el siguiente error obteniendo los títulos: {ex.Message}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		}
	}
}
