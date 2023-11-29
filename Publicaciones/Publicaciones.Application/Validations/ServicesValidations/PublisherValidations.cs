using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Publishers;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using System;

namespace Publicaciones.Application.Validations.ServicesValidations
{
    public class PublisherValidations : IPublisherValidations
    {
        private readonly IConfiguration _configurations; 

        public PublisherValidations(IConfiguration configurations)
        {
            this._configurations = configurations; 
        }
        public ServiceResult CommonValidations(PublisherDtoBase dtobase)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(dtobase.PubName))
            {
                string errorMessage = _configurations["ValidationMessage:PubNameRequired"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtobase.PubName.GetType() != typeof(string))
            {
                string errorMessage = _configurations["ValidationMessage:PubNameTyOFF"];
                throw new PublisherServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(dtobase.City))
            {
                string errorMessage = _configurations["ValidationMessage:CityRequired"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtobase.City.Length > 20)
            {
                string errorMessage = _configurations["ValidationMessage:CityMaxLenght"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtobase.City.Length < 5)
            {
                string errorMessage = _configurations["ValidationMessage:CityMinLenght"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtobase.City.GetType() != typeof(string))
            {
                string errorMessage = _configurations["ValidationMessage:CityTypeOFF"];
                throw new PublisherServiceException(errorMessage);
            }

            if (string.IsNullOrEmpty(dtobase.State))
            {
                string errorMessage = _configurations["ValidationMessage:StateRequired"];
                throw new PublisherServiceException  (errorMessage);
            }

            if (dtobase.State.GetType() != typeof(string))
            {
                string errorMessage = _configurations["ValidationMessage:StateTypeOFF"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtobase.State.Length > 2)
            {
                string errorMessage = _configurations["ValidationMessage:StateLenght"];
                throw new PublisherServiceException(errorMessage);
            }

            return result;
        }

        public ServiceResult DtoAddValidations(PublisherDtoAdd dtouadd)
        {
            ServiceResult result = CommonValidations(dtouadd);
            return result;
        }

        public ServiceResult DtoRemoveValidations(PublisherDtoRemove dtoremove)
        {
            ServiceResult result = new ServiceResult();

            if (dtoremove.PubID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidPublisherbID"];
                throw new PublisherServiceException(errorMessage);
            }

            if (dtoremove.Deleted == true)
            {
                string errorMessage = _configurations["ValidationMessage:ObjectRemove"];
                throw new PublisherServiceException(errorMessage);
            }

            return result;
        }

        public ServiceResult DtoUpdateValidations(PublisherDtoUpdate dtoupdate)
        {
            ServiceResult result = CommonValidations(dtoupdate);

            if (dtoupdate.PubID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidateID"];
                throw new JobServiceExeptions(errorMessage);
            }

            return result;
        }

    }
}
