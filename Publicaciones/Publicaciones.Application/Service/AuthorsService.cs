using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Authors;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Response;
using Publicaciones.Application.Validations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;
using System;
using System.Linq;
using System.Timers;

namespace Publicaciones.Application.Service
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly ILogger<AuthorsService> logger;
        private readonly IConfiguration configuration;

        public AuthorsService(IAuthorsRepository authorsRepository, 
                              ILogger<AuthorsService> logger,
                              IConfiguration configuration)
        {
            this._authorsRepository = authorsRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetEntities().Select(a => new AuthorsDtoGetAll()
                {
                    Au_ID = a.Au_ID,
                    Au_FName = a.Au_FName,
                    Au_LName = a.Au_LName,
                    Address = a.Address,
                    Phone = a.Phone,
                    City = a.City,
                    State = a.State,
                    Zip = a.Zip,
                    Contract = a.Contract
                });
                result.Message = this.configuration["AuthorSuccessMessages:GetAllSuccess"];
                result.Data = authors;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:GetAllError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authorsModel = this._authorsRepository.GetEntityByID(Id);
                result.Data = authorsModel;
                result.Message = this.configuration["AuthorSuccessMessages:GetByIDSuccess"];
            }

            catch(Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:GetByIdError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            
            return result;
        }

        public ServiceResult Remove(AuthorsDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult(); 
            try
            {
                Authors author = new Authors()
                {
                    Au_ID = dtoRemove.Id,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IDDeletedUser = dtoRemove.ChangeUser
                };
                this._authorsRepository.Remove(author);
                result.Message = this.configuration["AuthorSuccessMessages:RemoveSuccess"];
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:RemoveError"];
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(AuthorsDtoAdd dtoAdd)
        {

            AuthorResponse result = new AuthorResponse();
            try
            {
                AuthorsValidation.Validation(dtoAdd, configuration);
                Authors author = new Authors()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IDCreationUser = dtoAdd.ChangeUser,
                    Au_LName = dtoAdd.Au_LName,
                    Au_FName = dtoAdd.Au_FName,
                    Phone = dtoAdd.Phone,
                    Address = dtoAdd.Address,
                    City = dtoAdd.City,
                    State = dtoAdd.State,
                    Zip = dtoAdd.Zip,
                    Contract = dtoAdd.Contract,
                };
                this._authorsRepository.Save(author);
                result.Message = this.configuration["AuthorSuccessMessages:SaveSucces"];
                result.Au_ID = author.Au_ID;
            }
            catch (AuthorServiceException ssex)
            {
                result.Success = false;
                result.Message = ssex.Message;
                this.logger.LogError(result.Message, ssex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:SaveError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(AuthorsDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                AuthorsValidation.Validation(dtoUpdate, configuration);

                Authors author = new Authors()
                { 
                    Au_ID = dtoUpdate.Au_ID,
                    ModifiedDate = dtoUpdate.ChangeDate,
                    IDModifiedUser = dtoUpdate.ChangeUser,
                    Au_LName = dtoUpdate.Au_LName,
                    Au_FName = dtoUpdate.Au_FName,
                    Phone = dtoUpdate.Phone,
                    Address = dtoUpdate.Address,
                    City = dtoUpdate.City,
                    State = dtoUpdate.State,
                    Zip = dtoUpdate.Zip,
                    Contract = dtoUpdate.Contract,
                };
                this._authorsRepository.Update(author);
                result.Message = this.configuration["AuthorSuccessMessages:UpdateSuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:UpdateError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetAuthorsByCity(string city)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetAuthorsByCity(city);
                result.Data = authors;
                result.Message = this.configuration["AuthorSuccessMessages:GetByCitySuccess"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:GetByCityError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetAuthorsByState(string state)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetAuthorsByState(state);
                result.Data = authors;
                result.Message = this.configuration["AuthorSuccessMessages:GetByStateSuccess"];

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:GetByStateError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetAuthorsByContract(int contract)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var authors = this._authorsRepository.GetAuthorsByContract(contract);
                result.Data = authors;
                result.Message = this.configuration["AuthorSuccessMessages:GetByContractSuccess"]; 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["AuthorErrorMessages:GetByContractError"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
