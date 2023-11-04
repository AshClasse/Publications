using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class SaleValidation
    {
        public static void ValidateSaleID(int storeID, string ordNum, int titleID, IConfiguration configuration)
        {
            if (storeID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if(string.IsNullOrEmpty(ordNum))
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
            if (saleDtoAdd.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(saleDtoAdd.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(saleDtoAdd.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoAdd.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(saleDtoAdd.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoAdd.OrdNum.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumLength"]}";
                throw new SaleServiceException(errorMessage);
            }

            if(!IsValidOrdNumFormat(saleDtoAdd.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(saleDtoAdd.TitleID))
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoAdd.TitleID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(saleDtoAdd.OrdDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(saleDtoAdd.Qty))
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsShort"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoAdd.Qty <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(saleDtoAdd.Payterms))
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoAdd.Payterms.Length > 12)
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsLength"]}";
                throw new SaleServiceException(errorMessage);
            }
        }
        public static void ValidateUpdateSale(SaleDtoUpdate saleDtoUpdate, IConfiguration configuration)
        {
            if (saleDtoUpdate.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(saleDtoUpdate.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(saleDtoUpdate.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoUpdate.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(saleDtoUpdate.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoUpdate.OrdNum.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumLength"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!IsValidOrdNumFormat(saleDtoUpdate.OrdNum))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordNumFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(saleDtoUpdate.TitleID))
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoUpdate.TitleID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:titleIDIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(saleDtoUpdate.OrdDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:ordDateFormat"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(saleDtoUpdate.Qty))
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsShort"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoUpdate.Qty <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:qtyIsPositiveInt"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(saleDtoUpdate.Payterms))
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsRequired"]}";
                throw new SaleServiceException(errorMessage);
            }

            if (saleDtoUpdate.Payterms.Length > 12)
            {
                string errorMessage = $"{configuration["ValidationMessage:paytermsLength"]}";
                throw new SaleServiceException(errorMessage);
            }
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
            string patron = @"^ORD\d{3}$";

            return Regex.IsMatch(ordNum, patron);
        }
    }
}
