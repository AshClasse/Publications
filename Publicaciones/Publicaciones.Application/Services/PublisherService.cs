using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Publishers;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using Publicaciones.Application.Validations.ServicesValidations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly ILogger<PublisherService> logger;
        private readonly IConfiguration _configuration;
        private readonly IPublisherValidations _pubValidation;

        public PublisherService(IPublisherRepository _publisherRepository,
                                         ILogger<PublisherService> logger,
                                         IConfiguration _configurationm,
                                         IPublisherValidations _pubValidation)
        {
            this._publisherRepository = _publisherRepository;
            this.logger = logger;
            this._configuration = _configurationm;
            this._pubValidation = _pubValidation;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {

                var publishers = _publisherRepository.GetEntities().Select(PubsGet => new PublisherDtoGetAll()
                {
                    PubID = PubsGet.PubID,
                    PubName = PubsGet.PubName,
                    State = PubsGet.State,
                    Country = PubsGet.Country,
                    City = PubsGet.City,
                    ChangeDate = PubsGet.CreationDate,
                    ChangeUser = PubsGet.IDCreationUser
                });
                result.Data = publishers;
                result.Message = _configuration["PublisherSuccessMessages:getAllPublisherSuccessMessage"];

            }
            catch (PublisherServiceException exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["PublisherErrorMessage:getAllPublisherErrorMessage"];
                logger.LogError(result.Message, ex.ToString());

            }
            return result;
        } 

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var PublisherGet = _publisherRepository.GetEntityByID(ID);

                PublisherDtoGetAll pub = new PublisherDtoGetAll()
                {
                    PubID = PublisherGet.PubID,
                    PubName = PublisherGet.PubName,
                    State = PublisherGet.State,
                    Country = PublisherGet.Country,
                    City = PublisherGet.City,
                    ChangeDate = PublisherGet.CreationDate,
                    ChangeUser = PublisherGet.IDCreationUser
                };
                result.Data = pub;
                result.Message = _configuration["PublisherSuccessMessages:getPublisherSuccessMessage"];

            }
            catch (PublisherServiceException exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["PublisherErrorMessage:getPublisherErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }  

        public ServiceResult Remove(PublisherDtoRemove dtoremove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _pubValidation.DtoRemoveValidations(dtoremove);
                if(!validation.Success) 
                {
                    return validation;
                }
                else
                {
                    Publisher pubs = new Publisher()
                    {
                        PubID = dtoremove.PubID,
                        Deleted = dtoremove.Deleted,
                        DeletedUser = dtoremove.ChangeUser,
                        DeletedDate = dtoremove.ChangeDate
                    };
                    _publisherRepository.Remove(pubs);
                    result.Message = _configuration["PublisherSuccessMessages:removePublisherSuccessMessage"];

                }
            }
            catch (PublisherServiceException exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["PublisherErrorMessage:removedPublisherErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 
        public ServiceResult Save(PublisherDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _pubValidation.DtoAddValidations(dtoadd);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Publisher pubs = new Publisher()
                    {
                        PubName = dtoadd.PubName,
                        State = dtoadd.State,
                        Country = dtoadd.Country,
                        City = dtoadd.City,
                        IDCreationUser = dtoadd.ChangeUser,
                        ModifiedDate = dtoadd.ChangeDate
                    };
                    _publisherRepository.Save(pubs);
                    result.Message = _configuration["PublisherSuccessMessages:addPublisherSuccessMessage"];

                }
            }
            catch (PublisherServiceException exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["PublisherErrorMessage:addPublisherErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(PublisherDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _pubValidation.DtoUpdateValidations(dtoupdate);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Publisher pubs = new Publisher()
                    {
                        PubID = dtoupdate.PubID,
                        PubName = dtoupdate.PubName,
                        State = dtoupdate.State,
                        Country = dtoupdate.Country,
                        City = dtoupdate.City,
                        IDCreationUser = dtoupdate.ChangeUser,
                        ModifiedDate = dtoupdate.ChangeDate
                    };
                    _publisherRepository.Update(pubs);
                    result.Message = _configuration["PublisherSuccessMessages:updatePublisherSuccessMessage"];

                }
            }
            catch (PublisherServiceException exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["PublisherErrorMessage:updatePublisherErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 
    }
}
