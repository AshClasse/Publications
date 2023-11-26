using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using System;

namespace Publicaciones.Application.Validations.ServicesValidations
{
    public class JobValidations : IjobsValidations
    {
        private readonly IConfiguration _configurations;

        public JobValidations(IConfiguration _configurations)
        {
            this._configurations = _configurations;
        }

        public ServiceResult CommonValidations(JobsDtoBase dtobase)
        {
            ServiceResult result = new ServiceResult();

            // Validación de JobDescription
            if (string.IsNullOrEmpty(dtobase.JobDescription))
            {
                string errorMessage = _configurations["ValidationMessage:JobsDescriptionRequired"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.JobDescription.Length > 50)
            {
                string errorMessage = _configurations["ValidationMessage:JobsDescriptionMaxLenght"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.JobDescription.Length <= 10)
            {
                string errorMessage = _configurations["ValidationMessage:JobsDescriptionMinLenght"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.JobDescription.GetType() != typeof(string))
            {
                string errorMessage = _configurations["ValidationMessage:JobsDescriptionTypeOFF"];
                throw new JobServiceExeptions(errorMessage);
            }

            // Validación de Minlvl
            if (dtobase.Minlvl >= 255)
            {
                string errorMessage = _configurations["ValidationMessage:MaxlvlRequired"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.Minlvl.GetType() != typeof(byte))
            {
                string errorMessage = _configurations["ValidationMessage:MaxlvlRequired"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.Minlvl <= 0)
            {
                string errorMessage = _configurations["ValidationMessage:MinlvlMinLenght"];
                throw new JobServiceExeptions(errorMessage);
            }

            // Validación de Maxlvl
            if (dtobase.Maxlvl >= 255)
            {
                string errorMessage = _configurations["ValidationMessage:MaxlvlRequired"];
                throw new JobServiceExeptions(errorMessage);
            }

            if(dtobase.Maxlvl <= 0)
            {
                string errorMessage = _configurations["ValidationMessage:MaxlvlMinLenght"];
                throw new JobServiceExeptions(errorMessage);
            }

            if (dtobase.Maxlvl.GetType() != typeof(byte))
            {
                string errorMessage = _configurations["ValidationMessage:MaxlvlRequired"];
                throw new JobServiceExeptions(errorMessage);
            }
            return result;
        }

        public ServiceResult DtoAddValidations(JobsDtoAdd dtoadd)
        {
            ServiceResult result = CommonValidations(dtoadd);
            return result;
        }

        public ServiceResult DtoRemoveValidations(JobDtoRemove dtoromove)
        {
            ServiceResult result = new ServiceResult();

            // Validation JOBID
            if (dtoromove.JobID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidateID"];
                throw new JobServiceExeptions(errorMessage);
            }

            //Validation Deleted!
            if (dtoromove.Deleted == true)
            {
                string errorMessage = _configurations["ValidationMessage:ObjectRemove"];
                throw new JobServiceExeptions(errorMessage);
            }

            return result;
        }

        public ServiceResult DtoUpdateValidations(JobsDtoUpdate dtoupdate)
        {
            ServiceResult result = CommonValidations(dtoupdate);

            if (dtoupdate.JobID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidateID"];
                throw new JobServiceExeptions(errorMessage);
            }

            return result;
        }

    }
}
