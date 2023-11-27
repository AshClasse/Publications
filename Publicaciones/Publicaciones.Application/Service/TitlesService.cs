using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Response;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
	public class TitlesService : ITitlesService
	{
		private readonly ILogger<TitlesService> _logger;
		private readonly IConfiguration configuration;
		private readonly ITitlesRepository _titlesRepository;
		public TitlesService(ITitlesRepository titlesRepository, 
								ILogger<TitlesService> logger,
								IConfiguration configuration) 
		{
			this._titlesRepository = titlesRepository;
			this._logger = logger;
			this.configuration = configuration;
		}

		public ServiceResult GetAll()
		{
			ServiceResult result = new ServiceResult();
			try
			{

				result.Data = this._titlesRepository.GetTitlesPublishers();
				result.Message = $"{configuration["TitlesSuccessMessage:getAllSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:getAllErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		} 

		public ServiceResult GetByID(int id)
		{
			ServiceResult result = new ServiceResult();
			try
			{
				result.Data = this._titlesRepository.TitlePublisher(id);
				result.Message = $"{configuration["TitlesSuccessMessage:getByIdSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:getByIdErrorMessage"]}";
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
				result.Title_ID = titles.Title_ID;
				result.Message = $"{configuration["TitlesSuccessMessage:addSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:addErrorMessage"]}";
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
				result.Message = $"{configuration["TitlesSuccessMessage:updateSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:updateErrorMessage"]}";
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
				result.Message = $"{configuration["TitlesSuccessMessage:removeSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:removeErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;

		} 
		
		public ServiceResult Exists(int titleId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var exists = this._titlesRepository.Exists(tt => tt.Title_ID == titleId);

				if (!exists)
				{
					result.Success = false;

					if (titleId == 0)
					{
						result.Message = $"{configuration["ValidationMessage:titleIDRequired"]}";
					}
					else if (titleId < 0)
					{
						result.Message = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
					}
					else
					{
						result.Message = $"{configuration["ValidationMessage:titleIdExists"]}";
					}
				}

				result.Data = exists;
			}
			catch (Exception ex)
			{
				result.Success = false;
				this._logger.LogError(result.Message, ex.ToString());
			}
			return result;
		} 

		ServiceResult ITitlesService.ExistsInPublishers(int pubId)
		{
			ServiceResult result = new ServiceResult();

			try
			{
				var exists = this._titlesRepository.ExistsInPublishers(pubId);
				result.Data = exists;

				if (!exists)
				{
					result.Success = false;
					result.Message = $"{configuration["ValidationMessage:pubIdExists"]}";
				}

			}
			catch (Exception ex)
			{
				result.Success = false;
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
				result.Message = $"{configuration["TitlesSuccessMessage:getAllSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:getAllErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		} 

		ServiceResult ITitlesService.GetTitlesByPublisherID(int pubId)
		{
			ServiceResult result = new ServiceResult();
			try
			{

				result.Data = this._titlesRepository.GetTitlesByPublisherID(pubId);
				result.Message = $"{configuration["TitlesSuccessMessage:getAllSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:getAllErrorMessage"]}";
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
				result.Message = $"{configuration["TitlesSuccessMessage:getAllSuccessMessage"]}";
			}
			catch (TitlesServiceException ex)
			{
				result.Success = false;
				result.Message = ex.Message;
				this._logger.LogError(result.Message, ex.ToString());
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = $"{configuration["TitlesErrorMessage:getAllErrorMessage"]}";
				this._logger.LogError(result.Message, ex.ToString());
			}

			return result;
		} 

	}
}
