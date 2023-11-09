using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ServicesValidations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;
using System;
using System.Linq;

namespace Publicaciones.Application.Service
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepository _jobsRepository;
        private readonly ILogger<JobsService> logger;
        private readonly IConfiguration configuration;
        private readonly JobValidations _jobvalidations;

        public JobsService(IJobsRepository jobsRepository,
                           ILogger<JobsService> logger,
                           IConfiguration configuration,
                           JobValidations _jobvalidations)
        {
            _jobsRepository = jobsRepository;
            this.logger = logger;
            this.configuration = configuration;
            this._jobvalidations = _jobvalidations;
        }

        public ServiceResult Save(JobsDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _jobvalidations.DtoAddValidations(dtoadd);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Jobs jobs = new Jobs()
                    {
                        JobDescription = dtoadd.JobDescription,
                        Maxlvl = dtoadd.Maxlvl,
                        Minlvl = dtoadd.Minlvl,
                        IDCreationUser = dtoadd.ChangeUser,
                        CreationDate = dtoadd.ChangeDate
                    };
                    _jobsRepository.Save(jobs);
                    result.Message = configuration["JobSuccessMessages:addJobSuccessMessage"];
                }
            }
            catch (JobServiceExeptions exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = configuration["JobErrorMessage:addJobErrorMessage"];
                logger.LogError(result.Message, ex.Message);
            }
            return result;
        }

        public ServiceResult Update(JobsDtoUpdate dtoupdate) 
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _jobvalidations.DtoUpdateValidations(dtoupdate);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Jobs jobs = new Jobs()
                    {
                        JobID = dtoupdate.JobID,
                        JobDescription = dtoupdate.JobDescription,
                        Maxlvl = dtoupdate.Maxlvl,
                        Minlvl = dtoupdate.Minlvl,
                        IDCreationUser = dtoupdate.ChangeUser,
                        CreationDate = dtoupdate.ChangeDate
                    };

                    _jobsRepository.Update(jobs);
                    result.Message = configuration["JobSuccessMessages:updateSuccessMessage"];

                }
            }
             catch (JobServiceExeptions exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = configuration["JobErrorMessage:updateJobErrorMessage"];
                logger.LogError(result.Message, ex.Message);
                
            }
            return result;
        }  

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var jobs = _jobsRepository.GetEntities().Select(JobGet => new JobsDtoGetAll()
                {
                    JobID = JobGet.JobID,
                    JobDescription = JobGet.JobDescription,
                    Maxlvl = JobGet.Maxlvl,
                    Minlvl = JobGet.Minlvl,
                    ChangeDate = JobGet.CreationDate,
                    ChangeUser = JobGet.IDCreationUser
                });
                result.Data = jobs;
                result.Message = configuration["JobSuccessMessages:getAllJobsSuccessMessage"];

            }
            catch (JobServiceExeptions exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = configuration["JobErrorMessage:getAllJobErrorMessage"];
                logger.LogError(result.Message, ex.Message);
            }
            return result;
        } 

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result = new ServiceResult();
            {
                try
                {
                    var JobsGet = _jobsRepository.GetEntityByID(ID);

                    JobsDtoGetAll jobs = new JobsDtoGetAll()
                    {
                        JobID = JobsGet.JobID,
                        JobDescription = JobsGet.JobDescription,
                        Maxlvl = JobsGet.Maxlvl,
                        Minlvl = JobsGet.Minlvl,
                        ChangeDate = JobsGet.CreationDate,
                        ChangeUser = JobsGet.IDCreationUser
                    };
                    result.Data = jobs;
                    result.Message = configuration["JobSuccessMessages:getJobsSuccessMessage"];

                }
                catch (JobServiceExeptions exx)
                {
                    result.Success = false;
                    result.Message = exx.Message;
                    logger.LogError(result.Message, exx.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = configuration["JobErrorMessage:getJobErrorMessage"];
                    logger.LogError(result.Message, ex.Message);
                }
                return result;
            }
        } 

        public ServiceResult Remove(JobDtoRemove dtoremove)
        {
            var result = new ServiceResult();
            try
            {
                ServiceResult validation = _jobvalidations.DtoRemoveValidations(dtoremove);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Jobs jobs = new Jobs()
                    {
                        JobID = dtoremove.JobID,
                        Deleted = dtoremove.Deleted,
                        DeletedDate = dtoremove.ChangeDate,
                        DeletedUser = dtoremove.ChangeUser
                    };
                    _jobsRepository.Remove(jobs);
                    result.Message = configuration["JobSuccessMessages:removeSuccessMessage"];
                }
            }
            catch (JobServiceExeptions exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = configuration["JobErrorMessage:removeJobErrorMessage"];
                logger.LogError(result.Message, ex.Message);
            }
            return result;
        } 
    }
}
