using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;
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
        public EmployeeService(IEmployeeRepository employeeRepository, 
                                        ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            this.logger = logger;
                
        }

        //GET-ALL
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {

                var employees = _employeeRepository.GetEntities()
                        .Select(EmpGet => new EmployeeDtoGetAll()
                        {
                            EmpID = EmpGet.EmpID,
                            FirstName = EmpGet.FirstName,
                            LastName = EmpGet.LastName,
                            Minit = EmpGet.Minit,
                            Joblvl = EmpGet.Joblvl,
                            HireDate = EmpGet.HireDate,
                            JobID = EmpGet.JobID,
                            PubID = EmpGet.PubID,
                            ChangeDate = EmpGet.CreationDate,
                            ChangeUser = EmpGet.IDCreationUser
                        });
                        result.Data = employees;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred while obtaining the employees";
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
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = $"An error has ocurred while obtaining the employee";
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
                Employee employee = new Employee()
                {
                    EmpID = DtoRemove.EmpID,
                    FirstName = DtoRemove.FirstName,
                    LastName = DtoRemove.LastName,
                    Minit = DtoRemove.Minit,
                    Joblvl = DtoRemove.Joblvl,
                    HireDate = DtoRemove.HireDate,
                    CreationDate = DtoRemove.ChangeDate,
                    IDCreationUser = DtoRemove.ChangeUser,
                    Deleted = DtoRemove.Deleted
                };

                _employeeRepository.Remove(employee);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred while removing the employee";
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
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"The following error ocurred while saving the employee";
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
                Employee employee = new Employee()
                {
                    EmpID = dtoupdate.EmpID,
                    CreationDate = dtoupdate.ChangeDate,
                    IDCreationUser = dtoupdate.ChangeUser,
                    FirstName = dtoupdate.FirstName,
                    LastName = dtoupdate.LastName,
                    HireDate = dtoupdate.HireDate,
                    Joblvl = dtoupdate .Joblvl,
                    Minit = dtoupdate.Minit,
                    JobID = dtoupdate.JobID,
                    PubID = dtoupdate.PubID
                };
                _employeeRepository.Update(employee);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while updating the employee";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
