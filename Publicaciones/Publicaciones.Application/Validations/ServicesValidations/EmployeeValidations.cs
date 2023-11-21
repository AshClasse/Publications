using Microsoft.Extensions.Configuration;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using System;
using System.IO;

namespace Publicaciones.Application.Validations.ServicesValidations
{
    public class EmployeeValidations : IEmployeeValidations
    {
        private readonly IConfiguration _configurations;

        public EmployeeValidations(IConfiguration _configurations)
        {
            this._configurations = _configurations;
        }
        public ServiceResult CommonValidations(EmployeeDtoBase dtobase)
        {
            ServiceResult result = new ServiceResult();

            // Validation FirstName
            if (string.IsNullOrEmpty(dtobase.FirstName))
            {
                string errorMessage = $"{_configurations["ValidationMessage:FirstNameRequired"]}";           
                throw new EmployeeServiceExeption(errorMessage);
            }
            if (dtobase.FirstName.GetType() != typeof(string))
            {
                string errorMessage = $"{_configurations["ValidationMessage:FirstNameTyOFFString"]}";
                throw new EmployeeServiceExeption(errorMessage);
            }

            // Validation LastName
            if (string.IsNullOrEmpty(dtobase.LastName))
            {
                string errorMessage = $"{_configurations["ValidationMessage:LastNameRequired"]}";
                throw new EmployeeServiceExeption(errorMessage);
            }
            if (dtobase.LastName.GetType() != typeof(string))
            {
                string errorMessage = $"{_configurations["ValidationMessage:LastNameTyOFFString"]}";
                throw new EmployeeServiceExeption (errorMessage);
            }

            // Validation de HireDate
            if (dtobase.HireDate == DateTime.MinValue)
            {
                string errorMessage = _configurations["ValidationMessage:HireDateRequired"];
                throw new EmployeeServiceExeption(errorMessage);
            }

            if (dtobase.HireDate.GetType() != typeof(DateTime))
            {
                string errorMessage = _configurations["ValidationMessage:HireDateFormat"];
                throw new EmployeeServiceExeption(errorMessage);
            }
            return result;
        }

        public ServiceResult DtoAddValidations(EmployeeDtoAdd dtoupdate)
        {
            ServiceResult result = CommonValidations(dtoupdate);
            return result;
        }

        public ServiceResult DtoRemoveValidations(EmployeeDtoRemove dtoremove)
        {
            ServiceResult result = new ServiceResult();

            if (dtoremove.EmpID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidateID"];
                throw new EmployeeServiceExeption(errorMessage);
            }

            if (dtoremove.Deleted == true)
            {
                string errorMessage = _configurations["ValidationMessage:ObjectRemove"];
                throw new EmployeeServiceExeption(errorMessage);
            }
            return result;
        }

        public ServiceResult DtoUpdateValidations(EmployeeDtoUpdate dtoupdate)
        {
            ServiceResult result = CommonValidations(dtoupdate);

            if (dtoupdate.EmpID.GetType() != typeof(int))
            {
                string errorMessage = _configurations["ValidationMessage:ValidateID"];
                throw new EmployeeServiceExeption(errorMessage);
            }
            return result;
        }

    }
}
