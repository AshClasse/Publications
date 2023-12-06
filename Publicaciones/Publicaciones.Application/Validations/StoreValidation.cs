using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Application.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Publicaciones.Application.Validations
{
    public static class StoreValidation
    {
        private static void CommonValidation(
            int changeUser, DateTime changeDate, string storeName,
            string storeAddress, string city, string state, string zip,
            IConfiguration configuration)
        {
            if (changeUser <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:changeUserIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.IsValidDateFormat(changeDate))
            {
                string errorMessage = $"{configuration["ValidationMessage:changeDateFormat"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeName.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeName))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeNameContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(storeAddress))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeAddress.Length > 40)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(storeAddress))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeAddressContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(city))
            {
                string errorMessage = $"{configuration["ValidationMessage:cityRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (city.Length > 20)
            {
                string errorMessage = $"{configuration["ValidationMessage:cityLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(city))
            {
                string errorMessage = $"{configuration["ValidationMessage:cityContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(state))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (state.Length > 2)
            {
                string errorMessage = $"{configuration["ValidationMessage:stateLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyLetters(state))
            {
                string errorMessage = $"{configuration["ValidationMessage:stateContainsOnlyLetters"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipRequired"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (zip.Length > 5)
            {
                string errorMessage = $"{configuration["ValidationMessage:zipLength"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (!ValidationUtility.ContainsOnlyNumbers(zip))
            {
                string errorMessage = $"{configuration["ValidationMessage:zipContainsOnlyNumbers"]}";
                throw new StoreServiceException(errorMessage);
            }
        }

        public static void ValidateAddStore(StoreDtoAdd storeDtoAdd, IConfiguration configuration)
        {
            CommonValidation(
                storeDtoAdd.ChangeUser, storeDtoAdd.ChangeDate, storeDtoAdd.StoreName,
                storeDtoAdd.StoreAddress, storeDtoAdd.City, storeDtoAdd.State, storeDtoAdd.Zip, configuration);
        }

        public static void ValidateUpdateStore(StoreDtoUpdate storeDtoUpdate, IConfiguration configuration)
        {
            CommonValidation(
                storeDtoUpdate.ChangeUser, storeDtoUpdate.ChangeDate, storeDtoUpdate.StoreName,
                storeDtoUpdate.StoreAddress, storeDtoUpdate.City, storeDtoUpdate.State, storeDtoUpdate.Zip, configuration);

            if (!ValidationUtility.IsInt(storeDtoUpdate.StoreID))
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsInt"]}";
                throw new StoreServiceException(errorMessage);
            }

            if (storeDtoUpdate.StoreID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
                throw new StoreServiceException(errorMessage);
            }
        }

        public static void ValidateStoreID(int ID, IConfiguration configuration)
        {
            if (ID <= 0)
            {
                string errorMessage = $"{configuration["ValidationMessage:storeIDIsPositiveInt"]}";
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

            if (storeDtoRemove.Deleted == true)
            {
                string errorMessage = configuration["StoreErrorMessage:removeErrorMessage"];
                throw new DiscountServiceException(errorMessage);
            }
        }

    }
}
