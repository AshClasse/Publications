using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class DiscountValidation
    {
        public static void ValidateDiscountID(int ID, IConfiguration configuration)
        {
            if (ID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
        public static void ValidateAddDiscount(DiscountDtoAdd discountDtoAdd, IConfiguration configuration)
        {
            if (discountDtoAdd.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(discountDtoAdd.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(discountDtoAdd.DiscountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeRequired"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoAdd.DiscountType.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeLength"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(discountDtoAdd.DiscountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeContainsOnlyLetters"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoAdd.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(discountDtoAdd.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(discountDtoAdd.LowQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:lowQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(discountDtoAdd.HighQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:HighQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimal(discountDtoAdd.DiscountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimalFormatValid(discountDtoAdd.DiscountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
        public static void ValidateUpdateDiscount(DiscountDtoUpdate discountDtoUpdate, IConfiguration configuration)
        {
            if (discountDtoUpdate.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(discountDtoUpdate.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(discountDtoUpdate.DiscountID))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoUpdate.DiscountID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(discountDtoUpdate.DiscountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeRequired"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoUpdate.DiscountType.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeLength"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(discountDtoUpdate.DiscountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeContainsOnlyLetters"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoUpdate.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if(!ValidationUtility.IsInt(discountDtoUpdate.StoreID)) 
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(discountDtoUpdate.LowQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:lowQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(discountDtoUpdate.HighQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:HighQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimal(discountDtoUpdate.DiscountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimalFormatValid(discountDtoUpdate.DiscountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
        public static void ValidateRemoveDiscount(DiscountDtoRemove discountDtoRemove, IConfiguration configuration)
        {
            if (!ValidationUtility.IsInt(discountDtoRemove.DiscountID))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountDtoRemove.DiscountID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if(!discountDtoRemove.Deleted)
            {
                string errorMessage = $"{configuration["DiscountErrorMessage:removeErrorMessage"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
    }
}
