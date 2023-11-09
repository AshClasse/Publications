using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> logger;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeValidations _employeevalidations;
        public EmployeeService(IEmployeeRepository employeeRepository, 
                                        ILogger<EmployeeService> logger,
                                        IConfiguration _configuration,
                                        IEmployeeValidations _employeevalidations)
        {
            _employeeRepository = employeeRepository;
            this.logger = logger;
            this._configuration = _configuration;
            this._employeevalidations = _employeevalidations;
                
        }

        //GET-ALL
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = _employeeRepository.GetEmployeeJob();
                result.Message = _configuration["EmployeeSuccessMessages:getAllEmployeesSuccessMessage"];

            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:getAllEmployeessErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        //GETBY-ID
        public ServiceResult GetByID(int ID)
        {
            ServiceResult result= new ServiceResult();
            {
                try
                {
                    var EmpGet = _employeeRepository.GetEntityByID(ID);

                    EmployeeDtoGetAll employee = new EmployeeDtoGetAll()
                    {
                        EmpID = EmpGet.EmpID,
                        FirstName = EmpGet.FirstName,
                        LastName = EmpGet.LastName,
                        Minit = EmpGet.Minit,
                        Joblvl = EmpGet.Joblvl,
                        HireDate = EmpGet.HireDate,
                        PubID = EmpGet.PubID,
                        JobID= EmpGet.JobID,
                        ChangeDate = EmpGet.CreationDate,
                        ChangeUser = EmpGet.IDCreationUser
                    };
                    result.Data = employee;
                    result.Message = _configuration["EmployeeSuccessMessages:getEmployeeSuccessMessage"];

                }
                catch (EmployeeServiceExeption exx)
                {
                    result.Success = false;
                    result.Message = exx.Message;
                    logger.LogError(result.Message, exx.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["EmployeeErrorMessage:getEmployeeErrorMessage"];
                    logger.LogError(result.Message, ex.ToString());
                }
                return result;
            }
        } 
        //REMOVE
        public ServiceResult Remove(EmployeeDtoRemove DtoRemove)
        {
            ServiceResult result = new ServiceResult(); 
            try
            {
                ServiceResult validation = _employeevalidations.DtoRemoveValidations(DtoRemove);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        EmpID = DtoRemove.EmpID,
                        DeletedDate = DtoRemove.ChangeDate,
                        DeletedUser = DtoRemove.ChangeUser,
                        Deleted = DtoRemove.Deleted
                    };
                    _employeeRepository.Remove(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:removeEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:removedEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        //SAVE
        public ServiceResult Save(EmployeeDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _employeevalidations.DtoAddValidations(dtoadd);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        CreationDate = dtoadd.ChangeDate,
                        IDCreationUser = dtoadd.ChangeUser,
                        FirstName = dtoadd.FirstName,
                        LastName = dtoadd.LastName,
                        HireDate = dtoadd.HireDate,
                        Joblvl = dtoadd.Joblvl,
                        Minit = dtoadd.Minit,
                        JobID = dtoadd.JobID,
                        PubID = dtoadd.PubID
                    };
                    _employeeRepository.Save(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:addEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:addEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        //UPDATE
        public ServiceResult Update(EmployeeDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _employeevalidations.DtoUpdateValidations(dtoupdate);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        EmpID = dtoupdate.EmpID,
                        CreationDate = dtoupdate.ChangeDate,
                        IDCreationUser = dtoupdate.ChangeUser,
                        FirstName = dtoupdate.FirstName,
                        LastName = dtoupdate.LastName,
                        HireDate = dtoupdate.HireDate,
                        Joblvl = dtoupdate.Joblvl,
                        Minit = dtoupdate.Minit,
                        JobID = dtoupdate.JobID,
                        PubID = dtoupdate.PubID
                    };
                    _employeeRepository.Update(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:updateEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:updateEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 
    }
}
