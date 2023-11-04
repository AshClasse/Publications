using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class StoreValidation
    {
        public static void ValidateStoreID(int ID, IConfiguration configuration)
        {
            if (ID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }
        }
        public static void ValidateAddStore(StoreDtoAdd storeDtoAdd, IConfiguration configuration)
        {
            if (storeDtoAdd.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(storeDtoAdd.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoAdd.StoreName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoAdd.StoreName.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoAdd.StoreName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoAdd.StoreAddress))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoAdd.StoreAddress.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoAdd.StoreAddress))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoAdd.City))
            {
                string errorMessage = $"{configuration["ValidationMessage:cityRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoAdd.City.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:cityLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoAdd.City))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoAdd.State))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoAdd.State.Length > 2)
            {
                string errorMessage = $"{configuration["ValidationMessage:stateLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoAdd.State))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoAdd.Zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoAdd.Zip.Length > 5)
            {
                string errorMessage = $"{configuration["ValidationMessage:zipLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyNumbers(storeDtoAdd.Zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipContainsOnlyNumbers"]}";
                throw new StoreServiceException(errorMessage);
            }
        }
        public static void ValidateUpdateStore(StoreDtoUpdate storeDtoUpdate, IConfiguration configuration)
        {
            if (storeDtoUpdate.ChangeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(storeDtoUpdate.ChangeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.IsInt(storeDtoUpdate.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:discountIDIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoUpdate.StoreName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.StoreName.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoUpdate.StoreName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoUpdate.StoreAddress))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.StoreAddress.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoUpdate.City))
            {
                string errorMessage = $"{configuration["ValidationMessage:cityRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.City.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:cityLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoUpdate.City))
            {
                string errorMessage = $"{configuration["ValidationMessage:discountTypeContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoUpdate.State))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.State.Length > 2)
            {
                string errorMessage = $"{configuration["ValidationMessage:stateLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeDtoUpdate.State))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeDtoUpdate.Zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.Zip.Length > 5)
            {
                string errorMessage = $"{configuration["ValidationMessage:zipLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyNumbers(storeDtoUpdate.Zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipContainsOnlyNumbers"]}";
                throw new StoreServiceException(errorMessage);
            }
        }
        public static void ValidateRemoveStore(StoreDtoRemove storeDtoRemove, IConfiguration configuration)
        {
            if (!ValidationUtility.IsInt(storeDtoRemove.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoRemove.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!storeDtoRemove.Deleted)
            {
                string errorMessage = $"{configuration["StoreErrorMessage:removeErrorMessage"]}";
                throw new StoreServiceException(errorMessage);
            }
        }

    }
}
