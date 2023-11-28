using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Application.Exceptions;
using Publicaciones.Application.Validations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Diagnostics;

namespace Publicaciones.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly ILogger<SaleService> logger;
        private readonly IConfiguration configuration;

        public SaleService(ISaleRepository saleRepository,
                           ILogger<SaleService> logger,
                           IConfiguration configuration)
        {
            this.saleRepository = saleRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.saleRepository.GetSalesStoresAndTitles();
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred obtaining the sales.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.saleRepository.GetSaleStore(ID);
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred obtaining the sale.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetSaleByID(int storeID, string ordNum, int titleID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                SaleValidation.ValidateSaleID(storeID, ordNum, titleID, configuration);

                var sale = this.saleRepository.GetSaleStoreTitle(storeID, ordNum, titleID);

                SaleDtoGetAll saleModel = new SaleDtoGetAll()
                {
                    StoreID = sale.StoreID,
                    CreationDate = sale.CreationDate,
                    OrdNum = sale.OrdNum,
                    OrdDate = sale.OrdDate,
                    Qty = sale.Qty,
                    Payterms = sale.Payterms,
                    TitleID = sale.TitleID
                };
                result.Data = saleModel;
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["SaleErrorMessage:getSaleErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(SaleDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                SaleValidation.ValidateAddSale(dtoAdd, configuration);

                Sale sale = new Sale()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    IDCreationUser = dtoAdd.ChangeUser,
                    StoreID = dtoAdd.StoreID,
                    OrdNum = dtoAdd.OrdNum,
                    TitleID = dtoAdd.TitleID,
                    OrdDate = dtoAdd.OrdDate,
                    Qty = dtoAdd.Qty,
                    Payterms = dtoAdd.Payterms
                };

                this.saleRepository.Save(sale);
                result.Message = $"{configuration["SaleSuccessMessage:addSuccessMessage"]}";
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["SaleErrorMessage:addErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(SaleDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                SaleValidation.ValidateUpdateSale(dtoUpdate, configuration);

                Sale sale = new Sale()
                {
                    StoreID = dtoUpdate.StoreID,
                    OrdNum = dtoUpdate.OrdNum,
                    TitleID = dtoUpdate.TitleID,
                    ModifiedDate = dtoUpdate.ChangeDate,
                    IDModifiedUser = dtoUpdate.ChangeUser,
                    OrdDate = dtoUpdate.ChangeDate,
                    Qty = dtoUpdate.Qty,
                    Payterms = dtoUpdate.Payterms
                };

                this.saleRepository.Update(sale);
                result.Message = $"{configuration["SaleSuccessMessage:updateSuccessMessage"]}";
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message= $"{configuration["SaleErrorMessage:updateErrorMessage"]}";
                this.logger.LogError (result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(SaleDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                SaleValidation.ValidateRemoveSale(dtoRemove, configuration);

                Sale sale = new Sale()
                {
                    StoreID = dtoRemove.StoreID,
                    OrdNum = dtoRemove.OrdNum,
                    TitleID = dtoRemove.TitleID,
                    Deleted = dtoRemove.Deleted,
                };

                this.saleRepository.Remove(sale);
                result.Message = $"{configuration["SaleSuccessMessage:removeSuccessMessage"]}";
            }
            catch (SaleServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError(result.Message, ex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"{configuration["SaleErrorMessage:removeErrorMessage"]}";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
