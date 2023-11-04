using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class DiscountValidation
    {
        private static void CommonValidation(int changeUser, DateTime changeDate, string discountType, int storeID, short? lowQty, short? highQty, decimal discountAmount, IConfiguration configuration)
        {
            if (changeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(changeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(discountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeRequired"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (discountType.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeLength"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(discountType))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeContainsOnlyLetters"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (storeID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(storeID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(lowQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:lowQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsShort(highQty))
            {
                string errorMessage = $"{configuration["ValidationMessage:HighQtyIsShort"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimal(discountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }

            if (!ValidationUtility.IsDecimalFormatValid(discountAmount))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountAmountIsDecimal"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
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
            CommonValidation(discountDtoAdd.ChangeUser, discountDtoAdd.ChangeDate, discountDtoAdd.DiscountType, discountDtoAdd.StoreID, discountDtoAdd.LowQty, discountDtoAdd.HighQty, discountDtoAdd.DiscountAmount, configuration);
        }
        public static void ValidateUpdateDiscount(DiscountDtoUpdate discountDtoUpdate, IConfiguration configuration)
        {
            CommonValidation(discountDtoUpdate.ChangeUser, discountDtoUpdate.ChangeDate, discountDtoUpdate.DiscountType, discountDtoUpdate.StoreID, discountDtoUpdate.LowQty, discountDtoUpdate.HighQty, discountDtoUpdate.DiscountAmount, configuration);

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

            if (!discountDtoRemove.Deleted)
            {
                string errorMessage = $"{configuration["DiscountErrorMessage:removeErrorMessage"]}";
                throw new DiscountServiceException(errorMessage);
            }
        }
    }
}
