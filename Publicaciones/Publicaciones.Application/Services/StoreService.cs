using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Validations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Publicaciones.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository storeRepository;
        private readonly ILogger<StoreService> logger;
        private readonly IConfiguration configuration;

        public StoreService(IStoreRepository storeRepository,
                            ILogger<StoreService> logger,
                            IConfiguration configuration)
        {
            this.storeRepository = storeRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.storeRepository.GetStores();
            }
            catch (StoreServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred obtaining the stores.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                StoreValidation.ValidateStoreID(ID, configuration);
                result.Data = this.storeRepository.GetStore(ID);
            }
            catch (StoreServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["StoreErrorMessage:getStoreErrorMessage"]}";
                this.logger.LogError (result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(StoreDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                StoreValidation.ValidateAddStore(dtoAdd, configuration);

                Store store = new Store()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IDCreationUser = dtoAdd.ChangeUser,
                    StoreName = dtoAdd.StoreName,
                    StoreAddress = dtoAdd.StoreAddress,
                    City = dtoAdd.City,
                    State = dtoAdd.State,
                    Zip = dtoAdd.Zip
                };

                this.storeRepository.Save(store);
                result.Message = $"{configuration["StoreSuccessMessage:addSuccessMessage"]}";
            }
            catch (StoreServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["StoreErrorMessage:addErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(StoreDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                StoreValidation.ValidateUpdateStore(dtoUpdate, configuration);

                Store store = new Store()
                {
                    StoreID = dtoUpdate.StoreID,
                    ModifiedDate = dtoUpdate.ChangeDate,
                    IDModifiedUser = dtoUpdate.ChangeUser,
                    StoreName = dtoUpdate.StoreName,
                    StoreAddress = dtoUpdate.StoreAddress,
                    City = dtoUpdate.City,
                    State = dtoUpdate.State,
                    Zip = dtoUpdate.Zip
                };

                this.storeRepository.Update(store);
                result.Message = result.Message = $"{configuration["StoreSuccessMessage:updateSuccessMessage"]}";

            }
            catch (StoreServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["StoreErrorMessage:updateErrorMessage"]}";
                this.logger.LogError (result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(StoreDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                StoreValidation.ValidateRemoveStore(dtoRemove, configuration);

                Store store = new Store()
                {
                    StoreID = dtoRemove.StoreID,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    IDDeletedUser = dtoRemove.ChangeUser
                };

                this.storeRepository.Remove(store);
                result.Message = $"{configuration["StoreSuccessMessage:removeSuccessMessage"]}";
            }
            catch (StoreServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["StoreErrorMessage:removeErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
