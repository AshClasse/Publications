using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Publishers;
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

        public PublisherService(IPublisherRepository _publisherRepository,
                                         ILogger<PublisherService> logger)
        {
            this._publisherRepository = _publisherRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var publishers = _publisherRepository.GetEntities().Select(PubsGet => new PublisherDtoGetAll()
                {
                    PubName = PubsGet.PubName,
                    State = PubsGet.State,
                    Country = PubsGet.Country,
                    City = PubsGet.City,
                    ChangeDate = PubsGet.CreationDate,
                    ChangeUser = PubsGet.IDCreationUser
                });
                result.Data = publishers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred while obtaining the publishers";
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
                    PubName = PublisherGet.PubName,
                    State = PublisherGet.State,
                    Country = PublisherGet.Country,
                    City = PublisherGet.City,
                    ChangeDate = PublisherGet.CreationDate,
                    ChangeUser = PublisherGet.IDCreationUser
                };
                result.Data = pub;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred while obtaining the publisher";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(PublisherDtoRemove dtoremove)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                Publisher pubs = new Publisher()                
                {
                    PubID = dtoremove.PubID,
                    State = dtoremove.State,
                    Country = dtoremove.Country,
                    City = dtoremove.City,
                    IDCreationUser = dtoremove.ChangeUser,
                    ModifiedDate = dtoremove.ChangeDate
                };
                _publisherRepository.Remove(pubs);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while removing the publisher";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(PublisherDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
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

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $" An error has occured while saving the publisher";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(PublisherDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
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

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while updating the publisher";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
