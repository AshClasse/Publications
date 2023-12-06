using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Validations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;

namespace Publicaciones.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository discountRepository;
        private readonly ILogger<DiscountService> logger;
        private readonly IConfiguration configuration;

        public DiscountService(IDiscountRepository discountRepository, 
                               ILogger<DiscountService> logger,
                               IConfiguration configuration)
        {
            this.discountRepository = discountRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.discountRepository.GetDiscountsStores();
            }
            catch (DiscountServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["DiscountErrorMessage:getAllDiscountsErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DiscountValidation.ValidateDiscountID(ID, configuration);
                result.Data = this.discountRepository.GetDiscountStore(ID);
            }
            catch (DiscountServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["DiscountErrorMessage:getDiscountErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(DiscountDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DiscountValidation.ValidateAddDiscount(dtoAdd, configuration);
                Discount discount = new Discount()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IDCreationUser = dtoAdd.ChangeUser,
                    DiscountType = dtoAdd.DiscountType,
                    StoreID = dtoAdd.StoreID,
                    LowQty = dtoAdd.LowQty,
                    HighQty = dtoAdd.HighQty,
                    DiscountAmount = dtoAdd.DiscountAmount
                };

                this.discountRepository.Save(discount);
                result.Message = $"{configuration["DiscountSuccessMessage:addSuccessMessage"]}";
            }
            catch (DiscountServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["DiscountErrorMessage:addErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(DiscountDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DiscountValidation.ValidateUpdateDiscount(dtoUpdate, configuration);
                Discount discount = new Discount()
                {
                    DiscountID = dtoUpdate.DiscountID,
                    ModifiedDate = dtoUpdate.ChangeDate, 
                    IDModifiedUser = dtoUpdate.ChangeUser,
                    DiscountType = dtoUpdate.DiscountType,
                    StoreID = dtoUpdate.StoreID,
                    LowQty = dtoUpdate.LowQty,
                    HighQty = dtoUpdate.HighQty,
                    DiscountAmount = dtoUpdate.DiscountAmount
                };

                this.discountRepository.Update(discount);
                result.Message = $"{configuration["DiscountSuccessMessage:updateSuccessMessage"]}";
            }
            catch (DiscountServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["DiscountErrorMessage:updateErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(DiscountDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DiscountValidation.ValidateRemoveDiscount(dtoRemove, configuration);
                Discount discount = new Discount()
                {
                    DiscountID = dtoRemove.DiscountID,
                    Deleted = dtoRemove.Deleted
                };

                this.discountRepository.Remove(discount);
                result.Message = $"{configuration["DiscountSuccessMessage:removeSuccessMessage"]}";
            }
            catch (DiscountServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["DiscountErrorMessage:removeErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Exists(int discountID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var exists = this.discountRepository.Exists(pi => pi.DiscountID == discountID);

                if (!exists)
                {
                    result.Success = false;

                    if (discountID == 0)
                    {
                        result.Message = $"{configuration["ValidationMessage:discountIDRequired"]}";
                    }
                    else if (discountID < 0)
                    {
                        result.Message = $"{configuration["ValidationMessage:discountIDIsPositiveInt"]}";
                    }
                    else
                    {
                        result.Message = $"{configuration["ValidationMessage:discountIdExists"]}";
                    }
                }

                result.Data = exists;
            }
            catch (Exception ex)
            {
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
