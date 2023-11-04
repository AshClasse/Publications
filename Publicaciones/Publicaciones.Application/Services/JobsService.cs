using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;
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

        public JobsService(IJobsRepository jobsRepository,
                           ILogger<JobsService> logger)
        {
            _jobsRepository = jobsRepository;
            this.logger = logger;
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
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred while obtaining the jobs";
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
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = $"An error has ocurred while obtaining the job";
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
                Jobs jobs = new Jobs()
                {
                    JobID = dtoremove.JobID,
                    JobDescription = dtoremove.JobDescription,
                    Maxlvl = dtoremove.Maxlvl,
                    Minlvl = dtoremove.Minlvl,
                    IDCreationUser = dtoremove.ChangeUser,
                    CreationDate = dtoremove.ChangeDate,
                    Deleted = dtoremove.Deleted
                };
                _jobsRepository.Remove(jobs);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while removing the job";
                logger.LogError(result.Message, ex.Message);
            }
            return result;
        }

        public ServiceResult Save(JobsDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
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

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while saving the job";
                logger.LogError(result.Message, ex.Message);
            }
            return result;
        }

        public ServiceResult Update(JobsDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
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
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has occured while updating the job";
                logger.LogError(result.Message, ex.Message);
                
            }
            return result;
        }
    }
}
