using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class StoreValidation
    {
        private static void CommonValidation(int changeUser, DateTime changeDate, int storeID, string ordNum, int titleID, DateTime ordDate, short qty, string payterms, IConfiguration configuration)
        {
            if (changeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(changeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(storeID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (storeID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(ordNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (ordNum.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumLength"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!IsValidOrdNumFormat(ordNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(titleID))
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (titleID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(ordDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(qty))
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsShort"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (qty <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(payterms))
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (payterms.Length > 12)
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsLength"]}";
                throw new SaleServiceException(errorMessage);
            }
        }

        public static void ValidateSaleID(int storeID, string ordNum, int titleID, IConfiguration configuration)
        {
            if (storeID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(ordNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (titleID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }
        }

        public static void ValidateAddSale(SaleDtoAdd saleDtoAdd, IConfiguration configuration)
        {
            CommonValidation(saleDtoAdd.ChangeUser, saleDtoAdd.ChangeDate, saleDtoAdd.StoreID, saleDtoAdd.OrdNum, saleDtoAdd.TitleID, saleDtoAdd.OrdDate, saleDtoAdd.Qty, saleDtoAdd.Payterms, configuration);
        }

        public static void ValidateUpdateSale(SaleDtoUpdate saleDtoUpdate, IConfiguration configuration)
        {
            CommonValidation(saleDtoUpdate.ChangeUser, saleDtoUpdate.ChangeDate, saleDtoUpdate.StoreID, saleDtoUpdate.OrdNum, saleDtoUpdate.TitleID, saleDtoUpdate.OrdDate, saleDtoUpdate.Qty, saleDtoUpdate.Payterms, configuration);
        }

        public static void ValidateRemoveSale(SaleDtoRemove saleDtoRemove, IConfiguration configuration)
        {
            if (!ValidationUtility.IsInt(saleDtoRemove.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoRemove.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(saleDtoRemove.TitleID))
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoRemove.TitleID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(saleDtoRemove.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoRemove.OrdNum.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumLength"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!IsValidOrdNumFormat(saleDtoRemove.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!saleDtoRemove.Deleted)
            {
                string errorMessage = $"{configuration["SaleErrorMessage:removeErrorMessage"]}";
                throw new SaleServiceException(errorMessage);
            }
        }

        private static bool IsValidOrdNumFormat(string ordNum)
        {
            string pattern = @"^ORD\d{3}$";

            return Regex.IsMatch(ordNum, pattern);
        }

    }
}
